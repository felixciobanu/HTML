<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
function writeMsg() {
    echo "Vi jobber med nettsiden nå.";
}


?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<?php include "meny.html" ?>
<div id="wrapper3">
    <div class="upds eqh">
        <h2 style="border-bottom: solid black 2px; padding: 10px;">Nyheter</h2>
        <?php
        $sql = "SELECT * FROM finbil_v3.nyheter order by opplastningsdato desc;";
        $datasett = $tilkobling->query($sql);
        while ($rad = mysqli_fetch_array($datasett)) { ?>
        <h3>
            <?php echo $rad["tittel"];?>
        </h3>
            <img style="width: 250px;" src="<?php echo $rad["bildeadresse"];?>" alt="Ingen bilder tilgjengelige">
        <p style="border-bottom: solid black 2px; padding: 10px;">
            <?php echo $rad["innhold"];?>
        </p>
        <?php } ?>
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
                    echo "Onsdag! Jaja halveis i ukå då.";
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
            echo "Du oppdaterte sist " . date("H:i:sa"); echo ".";
            ?>
        </p>
    </div>
</div>
</body>
</html>