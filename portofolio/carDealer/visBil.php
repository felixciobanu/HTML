<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Vis Biler</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<?php include "meny.html" ?>
    <div id="small">
        <p>Søker du etter en spesiell bil?<a href="sok.php"> Trykk her</a></p>
        <p>Søker du etter biler i et bestemt lokale?<a href="bestemLokale.php"> Trykk her</a></p>
    </div>

        <?php
        $sql = "SELECT *
                from bil, drivstoff, girkasse, hjulsdrift, karroseri, merke, omraade, lokale, salgform
                where bil.merke=merke.id and bil.lokale=lokale.id and bil.salgsform=salgform.id and bil.omraade=omraade.id and bil.karroseri=karroseri.id and bil.drivstoff=drivstoff.id and bil.girkasse=girkasse.id and bil.hjuldrift = hjulsdrift.id  order by opplastningsdato desc;";
        $datasett = $tilkobling->query($sql);
        ?>
        <div id="pVisBil">
            <?php while($rad = mysqli_fetch_array($datasett)){ ?>
            <div id="biler">
                <img src="<?php echo $rad["bildeadresse"]; ?>" alt="Ingen tilgjengelige bilder av denne bilen.">
                <h4><?php echo $rad["tittel"]; ?></h4>
                <span id="bx1">
                    <span id="left">
                        <p><a href="visEnBil.php?regnr=<?php echo $rad["regnr"]?>"><?php echo $rad["bilmerke"]; ?> <?php echo $rad["model"]; ?> <?php echo $rad["aarstall"]; ?> </a></p>
                        <p>Pris: <?php echo $rad["pris"]; ?> Kr</p>
                        <p><?php echo $rad["sted"]; ?> </p>
                        <p><?php echo $rad["km"]; ?> Km</p>
                    </span>

                    <span id="right">
                        <p>Salgsform: <?php echo $rad["salgsform"]; ?></p>
                        <p><?php echo $rad["girkasse"]; ?></p>
                        <p>Drivstoff: <?php echo $rad["fuel"]; ?></p>
                        <p>Opplastningsdato: <br> <?php echo $rad["opplastningsdato"]; ?></p>
                    </span>
                </span>
            </div>
        <?php } ?>
    </div>
</body>
</html>