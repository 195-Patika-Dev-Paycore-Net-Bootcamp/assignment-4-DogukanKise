PGDMP     ,                     z            smartwastesystem    14.4    14.4     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16869    smartwastesystem    DATABASE     m   CREATE DATABASE smartwastesystem WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Turkish_Turkey.1254';
     DROP DATABASE smartwastesystem;
                postgres    false            ?            1259    16906 	   container    TABLE     ?   CREATE TABLE public.container (
    id bigint NOT NULL,
    container_name character varying(50) NOT NULL,
    latitude double precision NOT NULL,
    longitude double precision NOT NULL,
    vehicle_id bigint NOT NULL
);
    DROP TABLE public.container;
       public         heap    postgres    false            ?            1259    16905    container_id_seq    SEQUENCE     y   CREATE SEQUENCE public.container_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.container_id_seq;
       public          postgres    false    212            ?           0    0    container_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.container_id_seq OWNED BY public.container.id;
          public          postgres    false    211            ?            1259    16899    vehicle    TABLE     ?   CREATE TABLE public.vehicle (
    id bigint NOT NULL,
    vehicle_name character varying(50) NOT NULL,
    vehicle_plate character varying(14) NOT NULL
);
    DROP TABLE public.vehicle;
       public         heap    postgres    false            ?            1259    16898    vehicle_id_seq    SEQUENCE     w   CREATE SEQUENCE public.vehicle_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.vehicle_id_seq;
       public          postgres    false    210            ?           0    0    vehicle_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.vehicle_id_seq OWNED BY public.vehicle.id;
          public          postgres    false    209            b           2604    16909    container id    DEFAULT     l   ALTER TABLE ONLY public.container ALTER COLUMN id SET DEFAULT nextval('public.container_id_seq'::regclass);
 ;   ALTER TABLE public.container ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    211    212    212            a           2604    16902 
   vehicle id    DEFAULT     h   ALTER TABLE ONLY public.vehicle ALTER COLUMN id SET DEFAULT nextval('public.vehicle_id_seq'::regclass);
 9   ALTER TABLE public.vehicle ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    209    210    210            ?          0    16906 	   container 
   TABLE DATA           X   COPY public.container (id, container_name, latitude, longitude, vehicle_id) FROM stdin;
    public          postgres    false    212   ?       ?          0    16899    vehicle 
   TABLE DATA           B   COPY public.vehicle (id, vehicle_name, vehicle_plate) FROM stdin;
    public          postgres    false    210          ?           0    0    container_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.container_id_seq', 27, true);
          public          postgres    false    211                        0    0    vehicle_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.vehicle_id_seq', 4, true);
          public          postgres    false    209            f           2606    16911    container container_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.container
    ADD CONSTRAINT container_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.container DROP CONSTRAINT container_pkey;
       public            postgres    false    212            d           2606    16904    vehicle vehicle_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.vehicle
    ADD CONSTRAINT vehicle_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.vehicle DROP CONSTRAINT vehicle_pkey;
       public            postgres    false    210            g           2606    16912 #   container container_vehicle_id_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public.container
    ADD CONSTRAINT container_vehicle_id_fkey FOREIGN KEY (vehicle_id) REFERENCES public.vehicle(id);
 M   ALTER TABLE ONLY public.container DROP CONSTRAINT container_vehicle_id_fkey;
       public          postgres    false    212    210    3172            ?   "  x?m??J1??O??'X:?d?{٢?E? x?ņ]H?R_Ƨ???I?x3?o&g??z,sL?E??X??X?)? ?R???_c?s2?R汎?9???7//??mNCI??m?6?? yy?U?X!X?,??`C????m?V:?#?q????׸?V??*I?b?V?Al?PqW?;?'?cU??		?A???.?r?DY??w?C?z??wz?m???????a???]????x?YO`?Pe??8???U?E[(cS??k
??<?0?O
????.?????yn?1?>f      ?   R   x?3?t??46Q	R0?42?2?tu???X??qs??%????E-?L9KS29?????L?9??&?\1z\\\ ??"     