<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
$sql = sprintf("SELECT *
from bil, drivstoff, girkasse, hjulsdrift, karroseri, merke, omraade, lokale, salgform
where bil.merke=merke.id and bil.lokale=lokale.id and bil.salgsform=salgform.id and bil.omraade=omraade.id and bil.karroseri=karroseri.id 
and bil.drivstoff=drivstoff.id and bil.girkasse=girkasse.id and bil.hjuldrift = hjulsdrift.id and regnr='%s';"
    , $tilkobling->real_escape_string($_GET["regnr"]));
$datasett = $tilkobling->query($sql);
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<div id="wrapper2">
    <div id="visbilbox">
        <?php while($rad = mysqli_fetch_array($datasett)){?>
            <h1><?php echo $rad["tittel"];?></h1>
            <p><?php echo $rad["beskrivelse"];?></p>
            <p>Opplastningsdato: <?php echo $rad["opplastningsdato"];?></p>
            <div class="ltn-bx">
                <h2><?php echo $rad["regnr"];?></h2>
                <h2><?php echo $rad["sted"];?></h2>
            </div>
            <div class="ltn-bx">
                <p><?php echo $rad["fuel"];?></p>
                <p><?php echo $rad["girkasse"];?></p>
                <p><?php echo $rad["stil"];?></p>
                <p><?php echo $rad["karroseri"];?></p>
            </div>
            <div class="ltn-bx">
                <p><?php echo $rad["aarstall"];?></p>
                <p>Kilometer kjørt: <?php echo $rad["km"];?> km</p>
                <p>Pris: <?php echo $rad["pris"];?> kr</p>
            </div>
            <div class="ltn-bx">
                <p><?php echo $rad["bilmerke"];?><?php echo $rad["model"];?></p>
                <p>Hestekrefter: <?php echo $rad["hestekrefter"];?> hk</p>
                <p>Antall seter: <?php echo $rad["seter"];?></p>

            </div>
            <div class="ltn-bx">

                <p>Email: <?php echo $rad["email"];?></p>
                <p>Adresse: <?php echo $rad["adresse"];?></p>
            </div>
        <div class="ltn-bx">
            <p>Farge: <?php echo $rad["farge"];?></p>
            <p>Motor: <?php echo $rad["motor"];?></p>
            <p>Solgt: <?php echo $rad["solgt"];?></p>
        </div>
        <?php } ?>
    </div>
    <?php
    $sql = sprintf("SELECT *
from bilde
where regnr='%s';"
        , $tilkobling->real_escape_string($_GET["regnr"]));
    $datasett = $tilkobling->query($sql);
    ?>
    <div id="bilderBil">
        <?php while($rad = mysqli_fetch_array($datasett)){?>
            <img src="<?php echo $rad["bildeadresser"];?>" >
        <?php } ?>
    </div>
</div>
</body>
</html>