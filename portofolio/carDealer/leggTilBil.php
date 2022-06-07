<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
    $tilkobling->set_charset("utf8");
    if(isset($_POST["submit"])) {
        $sql = sprintf("INSERT INTO bil(regnr, tittel, merke, aarstall, pris, lokale, beskrivelse, km, salgsform, omraade, karroseri, drivstoff, 
girkasse, hjuldrift, motor, hestekrefter, seter, farge, bildeadresse, solgt)
        VALUES('%s', '%s','%s','%s', '%s', '%s','%s','%s', '%s', '%s','%s', '%s', '%s','%s','%s', '%s', '%s','%s','%s', '%s')",
            $tilkobling->real_escape_string($_POST["regnr"]),
            $tilkobling->real_escape_string($_POST["tittel"]),
            $tilkobling->real_escape_string($_POST["merke"]),
            $tilkobling->real_escape_string($_POST["aarstall"]),
            $tilkobling->real_escape_string($_POST["pris"]),
            $tilkobling->real_escape_string($_POST["lokale"]),
            $tilkobling->real_escape_string($_POST["beskrivelse"]),
            $tilkobling->real_escape_string($_POST["km"]),
            $tilkobling->real_escape_string($_POST["salgsform"]),
            $tilkobling->real_escape_string($_POST["omraade"]),
            $tilkobling->real_escape_string($_POST["karroseri"]),
            $tilkobling->real_escape_string($_POST["drivstoff"]),
            $tilkobling->real_escape_string($_POST["girkasse"]),
            $tilkobling->real_escape_string($_POST["hjuldrift"]),
            $tilkobling->real_escape_string($_POST["motor"]),
            $tilkobling->real_escape_string($_POST["hestekrefter"]),
            $tilkobling->real_escape_string($_POST["seter"]),
            $tilkobling->real_escape_string($_POST["farge"]),
            $tilkobling->real_escape_string($_POST["bildeadresse"]),
            $tilkobling->real_escape_string($_POST["solgt"])
        );
        $tilkobling->query($sql);
    }
$sql = "SELECT id, bilmerke, model
    FROM finbil_v3.merke
    order by bilmerke, model ASC;";
$datasett = $tilkobling->query($sql);

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Legg til Annonse</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
<?php include "meny2.html" ?>
<main id="main1">
    <h1>Legg til en bilannonse</h1>
    <p>Her legger du inn en ny bilannonse og nederst på siden kan du slette annonse ved å skrive inn regnr til bilen du hadde på annonsen.</p>
    <form method="post">
        <span class="span1">
            <input type="text" name="regnr" placeholder="Legg inn regnr. ">
            <input type="text" name="tittel" placeholder="Tittel(Max 150 Char.)">
            <select name="merke">
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["bilmerke"];?>
                        <?php echo $rad["model"];?>
                    </option>
                <?php } ?>
            </select>
            <input type="number" name="aarstall" placeholder="Legg til årstall">
        </span>
        <span class="span1">
            <input type="text" name="pris" placeholder="Legg til pris">
            <select name="lokale">
                <?php $sql = "SELECT * FROM finbil_v3.lokale";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["sted"];?>
                    </option>
                <?php } ?>
            </select>
            <textarea name="beskrivelse" placeholder="Sett inn en beskrivelse" rows="2" cols="40"></textarea>
            <input type="text" name="km" placeholder="Skriv inn km">
        </span>
        <span class="span1">
            <select name="salgsform">
                <?php $sql = "SELECT * FROM finbil_v3.salgform";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["salgsform"];?>
                    </option>
                <?php } ?>
            </select>
            <select name="omraade">
                <?php $sql = "SELECT * FROM finbil_v3.omraade";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["fylke"];?>
                    </option>
                <?php } ?>
            </select>
            <select name="karroseri">
                <?php $sql = "SELECT * FROM finbil_v3.karroseri";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["karroseri"];?>
                    </option>
                <?php } ?>
            </select>
            <select name="drivstoff">
                <?php $sql = "SELECT * FROM finbil_v3.drivstoff";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["fuel"];?>
                    </option>
                <?php } ?>
            </select>
            <select name="girkasse">
                <?php $sql = "SELECT * FROM finbil_v3.girkasse";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["girkasse"];?>
                    </option>
                <?php } ?>
            </select>
            <select name="hjuldrift">
                <?php $sql = "SELECT * FROM finbil_v3.hjulsdrift";
                $datasett = $tilkobling->query($sql); ?>
                <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["stil"];?>
                    </option>
                <?php } ?>
            </select>
        </span>
        <span class="span1">
            <input type="text" name="motor" placeholder="f.eks. TDI 2.0">
            <input type="number" name="hestekrefter" placeholder="Legg inn hestekrefter">
            <input type="number" name="seter" placeholder="Skriv inn antall seter">
        </span>
        <span class="span1">
            <input type="text" name="farge" placeholder="Skriv inn fargen">
            <input type="text" name="bildeadresse" placeholder="Legg til bildeadresse">
            <input type="text" name="solgt" placeholder="Solgt? ja/nei">
        </span></br>
        <button name="submit" type="submit"> Legg til bil </button>
    </form>
    <?php
    if(isset($_POST["submit4"])) {
        $sql = sprintf("INSERT INTO bilde(regnr, bildeadresser) VALUES('%s', '%s')",
            $tilkobling->real_escape_string($_POST["regnr"]),
            $tilkobling->real_escape_string($_POST["bildeadresser"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <h1>Legg til bilder (disse vises i hver bils enkeltnettside):</h1>
    <form method="post">
        <input type="text" name="regnr" placeholder="Skriv inn Regnr." >
        <input type="text" name="bildeadresser" placeholder="Legg til bildeadresse" >
        <button type="submit" name="submit4">Legg til bildet.</button>
    </form>
    <?php
    if(isset($_POST["submit2"])) {
        $sql = sprintf("DELETE FROM `finbil_v3`.`bil` WHERE (`regnr` = '%s');",
            $tilkobling->real_escape_string($_POST["regnr"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <p> Dersom du vil se dine bilannonser <a href="visBil.php">trykk her</a>.</p>
    <h1>Slett annonse:</h1>
    <form method="post">
        <input type="text" name="regnr" placeholder="Skriv inn Regnr." >
        <button type="submit" name="submit2">Slett annonse</button>
    </form>
    <?php
    if(isset($_POST["submit3"])) {
        $sql = sprintf("UPDATE `finbil_v3`.`bil` SET `pris` = '%s' WHERE (`regnr` = '%s');
",
            $tilkobling->real_escape_string($_POST["pris"]),
            $tilkobling->real_escape_string($_POST["regnr"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <h1>Forandre pris på bilannonse:</h1>
    <form method="post">
        <input type="number" name="pris" placeholder="Skriv inn ny pris" >
        <input type="text" name="regnr" placeholder="Skriv inn Regnr." >
        <button type="submit" name="submit3">Forandre pris</button>
    </form>

</main>

</body>
</html>