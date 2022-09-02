using Data.Model.Concrete;
using Dto.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dogukan_Kisecuklu_Hafta_3.Util
{
    public class KMeans
    {
        public List<List<Container>> Cluster(IEnumerable<ContainerDto> containers, int n, int vehicleId)
        {
            List<Container> temp = DtoToList(containers).Where(x => x.vehicle_id == vehicleId).ToList(); // Saf verinin değişmemesi için geçici bir list oluşturuldu.

            bool changed = true; bool success = true;
            int[] clustering = InitClustering(temp.Count, n); // Veriler rastgele kümelere aktarıldı
            double[][] centerPoints = Allocate(n); // Merkez noktaları oluşturulur ve varsayılan değeri 0,0 olarak belirlendi.
            int maxCount = temp.Count * 10; // Maksimum  Container içindeki değerin 10 katı kadar sınırlama getirildi.
            int counter = 0;
            while (changed && success && counter < maxCount)
            {
                /* Döngüye her girdiğinde kümeler arasında değişen olup olmadığı kontrol edilmektedir.
                 * success ve changed değişkeni true döndüğü sürece döngü devam etmekdir.
                 * Counter her seferinde artılırak sınırlandırma işleminde kontrol sağlanmaktadır.
                 */
                counter++;
                success = UpdateMeans(temp, clustering, centerPoints);
                changed = UpdateClustering(temp, clustering, centerPoints);
            }
            return ClusterContainers(temp, clustering, n);
        }

        private List<Container> DtoToList(IEnumerable<ContainerDto> containers)
        {
            /* Dto tipini List'e çevirme işlemi yapılmaktadır.
             * IEnumerable olarak verilen container dto'lar Liste aktarılmaktadır.
             * Aktarıdıktan sonra Cluster fonksiyonunda işleme sokulmaktadır.
             */
            List<Container> containerList = new List<Container>(); 
            foreach (var item in containers)
            {
                containerList.Add(new Container
                {
                    container_name = item.container_name,
                    id = item.id,
                    vehicle_id = item.vehicle_id,
                    latitude = item.latitude,
                    longitude = item.longitude
                });
            }
            return containerList;
        }
        private List<List<Container>> ClusterContainers(List<Container> containers, int[] clustering, int n)
        {
            List<List<Container>> clusteredContainers = new List<List<Container>>();
            for (int i = 0; i < n; i++)
                clusteredContainers.Add(new List<Container>()); // Küme sayısı kadar alt list oluşturulur.
            for (int i = 0; i < containers.Count; i++)
                clusteredContainers[clustering[i]].Add(containers[i]); // Veriye ait küme indexine göre listin indexi belirtilip veri eklenir.
            return clusteredContainers;
        }
        private bool UpdateMeans(List<Container> containers, int[] clustering, double[][] centerPoints)
        {
            int n = centerPoints.Length;
            int[] clusterCounts = new int[n];
            for (int i = 0; i < containers.Count; i++)
            {
                int cluster = clustering[i]; // Verinin hangi kümede olduğu tespit edilmektedir.
                clusterCounts[cluster]++; // Tespit edilen kümenin eleman sayısı 1 artırılmaktadır.
            }
            for (int i = 0; i < n; i++)
                if (clusterCounts[i] == 0) // Eğer kümenin elemanı kalmadıysa false olarak dönüş sağlamaktadır.
                    return false;

            for (int k = 0; k < centerPoints.Length; ++k)
                for (int j = 0; j < centerPoints[k].Length; ++j)
                    centerPoints[k][j] = 0.0;

            for (int i = 0; i < containers.Count; i++)
            {
                int cluster = clustering[i];
                centerPoints[cluster][0] += containers[i].latitude;
                centerPoints[cluster][1] += containers[i].longitude;
                //Longitude ve Latitude değerleri kümelerin merkez noktalarına eklenmektedir.
            }

            for (int i = 0; i < centerPoints.Length; i++)
                for (int j = 0; j < 2; j++)
                    centerPoints[i][j] /= clusterCounts[i]; // Merkez noktalarının koordinatları toplam X ve Y değerlerinin ortalamasına göre belirlenmektedir.
            return true;
        }
        private double[][] Allocate(int n)
        {
            double[][] result = new double[n][];//Kümelere ait merkez noktalar oluşturulmaktadır.
            for (int i = 0; i < n; i++)
                result[i] = new double[2];//İlk değer olarak bütün merkez noktalar 0,0 verilmektedir.
            return result;
        }

        private bool UpdateClustering(List<Container> containers, int[] clustering, double[][] centerPoints)
        {
            int n = centerPoints.Length;
            bool changed = false;

            int[] newClustering = new int[clustering.Length]; // Koordinatlara göre farklı bir merkez noktaya yakın olan verileri tespit edebilmek için yeni kümeleme arrayi oluşturulmaktadır.
            Array.Copy(clustering, newClustering, clustering.Length);

            double[] distances = new double[n]; // Koordinatların merkez noktalara olan uzaklığını belirlemek için oluşturulan array

            for (int i = 0; i < containers.Count; i++)
            {
                for (int k = 0; k < n; k++)
                    distances[k] = Distance(containers[i], centerPoints[k]);

                int newClusterID = MinIndex(distances); // Eğer veri, farklı bir merkez noktaya daha yakınsa o kümeye taşınmaktadır.
                if (newClusterID != newClustering[i])
                {
                    changed = true; // Kümeler üzerinde değişim olduğu için changed true olarak belirleniyor.
                    newClustering[i] = newClusterID;
                }
            }

            if (!changed)// Değişim olmadıysa bu adımdan sonrasının yapılmasına gerek duyulmadığı için false returnleniyor.
                return false;

            int[] clusterCounts = new int[n]; // Değişim olduğu için kümelerdeki eleman sayısı da değişmektedir.
            for (int i = 0; i < containers.Count; i++) // Bu nedenle yeni eleman sayılarını belirlemek için bilgiler aktarılamaktadır.
            {
                int cluster = newClustering[i];
                clusterCounts[cluster]++;
            }

            for (int i = 0; i < n; i++)
                if (clusterCounts[i] == 0) // Eğer eleman sayısı 0 olan bir küme varsa değişim yapılamayacağı için false döndürülmektedir.
                    return false;

            Array.Copy(newClustering, clustering, newClustering.Length); // Geçici bilgiler list'in son haline aktarılıyor. 
            return true;
        }
        private double Distance(Container data, double[] centerPoint)
        {
            double sumSquaredDiffs = 0.0;
            sumSquaredDiffs += Math.Pow((data.latitude - centerPoint[0]), 2); // X değerleri
            sumSquaredDiffs += Math.Pow((data.longitude - centerPoint[1]), 2); // Y değerleri
            return Math.Sqrt(sumSquaredDiffs); // Noktalar arası uzaklık formulü uygulanmaktadır.
        }
        private int MinIndex(double[] distances)
        {
            int indexOfMin = 0;
            double smallDist = distances[0]; // En küçük uzaklık ilk veri olarak kabul edilir.
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < smallDist) // Eğer en küçük uzaklıktan daha küçük uzaklık varsa veriye ait küme indexi değişir.
                {
                    smallDist = distances[i]; // En küçük uzaklık değişir.
                    indexOfMin = i; // En küçük uzaklığa ait kümenin indexi değişir
                }
            }
            return indexOfMin;
        }

        private int[] InitClustering(int count, int n) // Veriler rastgele kümelere atanmaktadır.
        {
            Random rnd = new Random(); // Random 
            int[] clustering = new int[count]; // Verilerin rastgele atandığı bölüm
            for (int i = 0; i < n; i++)
                clustering[i] = i; // Hiçbir kümenin boş kalmaması için ilk n kümeye eleman dağıtımı yapılmaktadır
            for (int i = n; i < clustering.Length; i++) // Geri kalan veriler rastgele kümelere atanmaktadır.
                clustering[i] = rnd.Next(0, n);
            return clustering;
        }
    }
}
