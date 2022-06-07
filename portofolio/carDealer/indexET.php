<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<?php include "meny2.html" ?>
<main>
    <div class="upds eqh">
        <h2>Velkommen tilbake Admin!</h2>
        <p>
            Ny dag, nye muligheter. Bruk dem godt!
        </p>
    </div>
    <div id="bx2" class="eqh">
        <?php include 'slider.html' ?>
    </div>
    <div class="upds eqh">
        <h2>Oppdateringer</h2>
        <p>
            I dag er det,
            <?php
            $dager = date("w");
            switch ($dager){
                case 1:
                    echo "Årh! Nei! Ikke mandag igjen...";
                    break;
                case 2:
                    echo "Tirsdag... ork";
                    break;
                case 3:
                    echo "Onsdag! Jaja halveis i uka då.";
                    break;
                case 4:
                    echo "Torsdag! AKA lillefredag!";
                    break;
                case 5:
                    echo "Fredag! TGIF!";
                    break;
                case 6:
                    echo "Lørdag. Godt med helg!";
                    break;
                case 0:
                    echo "Søndag.";
                    break;
            }
            ?><br />
        </p>
        <p>
            <?php
            date_default_timezone_set("Europe/Oslo");
            echo "Siden ble sist oppdatert " . date("H:i:sa"); echo ".";
            ?>
        </p>
    </div>
</main>
</body>
</html>