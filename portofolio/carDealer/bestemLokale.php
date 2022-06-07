<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
if(isset($_GET["submit"])) {
    $sql = sprintf("SELECT * 
                            FROM bil 
                            WHERE bil.tittel LIKE '%%%s%%';",
        $tilkobling->real_escape_string($_GET["tittel"])
    );
    echo $sql;
    $datasett = $tilkobling->query($sql);
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
<?php include 'meny.html'; ?>
<main class="bx4">

    <?php
    if(isset($_GET["submit2"])) {
        $sql = sprintf("SELECT * FROM `finbil_v3`.`bil`,`finbil_v3`.`merke`,`finbil_v3`.`lokale`,`finbil_v3`.`drivstoff` WHERE bil.lokale=lokale.id and bil.drivstoff=drivstoff.id and merke.id=bil.merke and lokale.id LIKE '%%%s%%'  order by opplastningsdato desc;",
            $tilkobling->real_escape_string($_GET["merke"])
        );
        $datasett = $tilkobling->query($sql);
    }
    $sql = "SELECT *
    FROM finbil_v3.lokale";
    $datasett2 = $tilkobling->query($sql);

    ?>
    <div class="soker">
        <form method="get">
            <select name="merke">
                <?php while($rad = mysqli_fetch_array($datasett2)) { ?>
                    <option value="<?php echo $rad["id"]; ?>">
                        <?php echo $rad["sted"];?>
                    </option>
                <?php } ?>
            </select>
            <button type="submit" name="submit2">søk etter bil</button>
        </form>
    </div>
    <div class="resultater">

        <?php if(isset($datasett)) while($rad = mysqli_fetch_array($datasett)){?>
            <div class="bx3">
                <h3><a href="visEnBil.php?regnr=<?php echo $rad["regnr"]?>"><?php echo $rad["tittel"]; ?></a></h3>
                <img src="<?php echo $rad["bildeadresse"]; ?>" alt="ingen bilder">
                <span class="bx2">
                    <p><?php echo $rad["fuel"]; ?></p>
                    <p><?php echo $rad["pris"]; ?> kr</p>
                    <p><?php echo $rad["bilmerke"]; ?> <?php echo $rad["model"]; ?></p>
                    <p><?php echo $rad["km"]; ?> km</p>
               </span>
            </div>
        <?php } ?>
    </div>
</main>
</body>
</html>