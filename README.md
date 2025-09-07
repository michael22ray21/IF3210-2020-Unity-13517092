# IF3210-2020-Unity-13517092

1. Deskripsi aplikasi  
    Aplikasi ini dikerjakan untuk memenuhi tugas besar 2 mata kuliah IF3210 Pengembangan Aplikasi Pada Platform Khusus.

2. Cara kerja, terutama mengenai pemenuhan spesifikasi aplikasi  
    Cara kerja sangat simpel, cukup buka scene Main lalu tekan play.
    Pemenuhan spesifikasi:  
    a. Terdapat karakter, GameObject Player. Dalam bentuk prefab di assets
    b. Karakter dapat digerakkan baik dengan W, A, S, dan D, ataupun dengan *arrow buttons*  
    c. Sound effect saat menembak ada dalam assets/shoot  
    d. Pergerakan kamera menggunakan utilitas Cinemachine dari Unity  
    e. Musuh pemain ada 2 jenis yaitu EnemyBat dan EnemyBee, masing-masing akan mengurangi darah pemain bila bersentuhan dengan pemain  
    g. Karakter memiliki *health* awal 100 dan 3 *lives*, bila ketiga *lives* telah habis, game akan berakhir  
    h. Desain peta menggunakan tilemap dan tile pallete  
    i. Game dapat menampilkan *score* pemain, tiap enemy yang dibunuh memberikan 10 poin  
    j. Game belum dapat menyimpan *score* pemain dalam basis data online  
    k. Scene menu ada dan juga scene permainan, namun scene scoreboard belum sempat diimplementasikan  
    l. Settings dari game tidak ada  
    m. Kebanyakan dari *assets* yang digunakan di project ini adalah *free assets* dari <https://www.kenney.nl/assets>  
    n. Game dibuat sesuai platform saya, yaitu MacOS

4. Library yang digunakan dan justifikasi penggunaannya  
    Library tambahan yang digunakan hanyalah Cinemachine, digunakan untuk mengaplikasikan kamera mengikuti player

5. Screenshot aplikasi  
![screenshot1](https://raw.githubusercontent.com/michael22ray21/IF3210-2020-Unity-13517092/master/Screenshots/SS1.png)
![screenshot2](https://raw.githubusercontent.com/michael22ray21/IF3210-2020-Unity-13517092/master/Screenshots/SS2.png)


---

1. Application Description  
    This application is developed to fulfill the requirements for the course IF3210 Platform-based Application Development.

2. Application details, mainly concerning the fulfillment of the requirements  
To run, simply open the `Main` scene and press "Play".

    Requirements:  
    a. The character is the GameObject Player, in the form of a prefab in `/assets`.  
    b. The character is moveable using the W, A, S, D and/or the arrow buttons.  
    c. Shooting sound effect is in the `assets/shoot`.  
    d. Camera movements is using the Cinemachine utility from Unity.  
    e. There are two types of enemies, EnemyBat and EnemyBee. Each type will decrease the players health when they come into contact with the player.  
    g. The player character has 100 initial health and 3 lives. If all the lives are lost, the game will end.  
    h. Map design used the tilemap and tile pallete.  
    i. Game can show the player's score, with each enemy killed rewards 10 points.  
    j. Game isn't able to store players' score in a database system.  
    k. There is a menu scene as well as a game scene, but the scoreboard hasn't been implemented yet.  
    l. The game doesn't have any adjustable settings yet.  
    m. Most of the assets used in this project is from the free assets in this [link](https://www.kenney.nl/assets).  
    n. The game is developed on my laptop's platform, MacOS.

3. Libraries used  
    Additional libraries used in this project is only Cinemachine. It is used to configure the camera movements to follow the player.
