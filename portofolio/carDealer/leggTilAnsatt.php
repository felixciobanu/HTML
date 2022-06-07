<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
    if(isset($_POST["submit"])) {
        $sql = sprintf("INSERT INTO ansatte(telefonnummer, navn, etternavn, email)
        VALUES('%s', '%s','%s','%s')",
        $tilkobling->real_escape_string($_POST["telefonnummer"]),
        $tilkobling->real_escape_string($_POST["navn"]),
        $tilkobling->real_escape_string($_POST["etternavn"]),
        $tilkobling->real_escape_string($_POST["email"])
        );
        $tilkobling->query($sql);
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
<?php include "meny2.html" ?>
<main id="main1">
    <h1>Legg til en ansatt</h1>
    <p>Her kan du legge til ny ansatt, se hvilke ansatte du har slette ansatte og sette hvilken jobb og stilling de har.</p>
    <form method="post">
        <input type="number" name="telefonnummer" placeholder="Legg til telefonnummer">
        <input type="text" name="navn" placeholder="Skriv inn fornavn">
        <input type="text" name="etternavn" placeholder="Skriv inn etternavn">
        <input type="text" name="email" placeholder="Legg til email">
        <button type="submit" name="submit">Bekreft</button>
    </form>
    <?php
    $sql = "Select * 
    From finbil_v3.ansatte;";
    $datasett = $tilkobling->query($sql);
    ?>
    <h1>Her er dine ansatte:</h1>
    <table>
        <tr>
            <th>telefonnummer</th>
            <th>Navn</th>
            <th>Etternavn</th>
            <th>Email</th>
        </tr>
        <?php while($rad = mysqli_fetch_array($datasett)) { ?>
            <tr>
                <td><?php echo $rad["telefonnummer"]; ?></td>
                <td><?php echo $rad["navn"]; ?></td>
                <td><?php echo $rad["etternavn"]; ?></td>
                <td><?php echo $rad["email"]; ?></td>
            </tr>
        <?php } ?>
    </table>
    <?php
    if(isset($_POST["submit2"])) {
        $sql = sprintf("DELETE FROM `finbil_v3`.`ansatte` WHERE (`telefonnummer` = '%s');",
            $tilkobling->real_escape_string($_POST["telefonnummer"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <h1>Slett ansatt:</h1>
    <form method="post">
        <input type="number" name="telefonnummer" placeholder="Skriv inn telefonnummeret">
        <button type="submit" name="submit2">Slett ansatt</button>
    </form>
    <h1>Her legger du til hvor folk jobber:</h1>
    <?php if(isset($_POST["submit3"])) {
    $sql = sprintf("INSERT INTO jobber(ansatte_telefonnummer, lokalet_id, stilling)
    VALUES('%s', '%s','%s')",
    $tilkobling->real_escape_string($_POST["ansatte_telefonnummer"]),
    $tilkobling->real_escape_string($_POST["lokalet_id"]),
    $tilkobling->real_escape_string($_POST["stilling"])
    );
    $tilkobling->query($sql);
    }
    ?>
    <form method="post">
        <?php
        $sql = "Select * 
        From finbil_v3.ansatte;";
        $datasett = $tilkobling->query($sql);
        ?>
        <select name="ansatte_telefonnummer">
            <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                <option value="<?php echo $rad["telefonnummer"]; ?>">
                    <?php echo $rad["navn"];?>
                    <?php echo $rad["etternavn"];?>
                </option>
            <?php } ?>
        </select>
        <?php
        $sql = "Select * 
        From finbil_v3.lokale;";
        $datasett = $tilkobling->query($sql);
        ?>
        <select name="lokalet_id">
            <?php while($rad = mysqli_fetch_array($datasett)) { ?>
                <option value="<?php echo $rad["id"]; ?>">
                    <?php echo $rad["sted"];?>
                </option>
            <?php } ?>
        </select>
        <input type="text" name="stilling" placeholder="Navn på stilling">
        <button type="submit" name="submit3">Bekreft</button>
    </form>
    <h1>Her er hvor ansatte jobber</h1>
    <?php
    $sql = "SELECT *
FROM jobber, lokale, ansatte
where ansatte_telefonnummer=telefonnummer and lokalet_id=id;";
    $datasett = $tilkobling->query($sql);
    ?>
    <table>
        <tr>
            <th>Ansatte telefonnummer</th>
            <th>Ansatte navn</th>
            <th>Lokalet_id</th>
            <th>Stilling</th>
        </tr>
        <?php while($rad = mysqli_fetch_array($datasett)) { ?>
            <tr>
                <td><?php echo $rad["telefonnummer"]; ?></td>
                <td><?php echo $rad["navn"];?> <?php echo $rad["etternavn"]; ?></td>
                <td><?php echo $rad["sted"]; ?></td>
                <td><?php echo $rad["stilling"]; ?></td>
            </tr>
        <?php } ?>
    </table>
    <h1>Slett ansatt sin stilling</h1>
    <?php
    if(isset($_POST["submit2"])) {
        $sql = sprintf("DELETE FROM `finbil_v3`.`jobber` WHERE (`ansatte_telefonnummer` = '%s');",
            $tilkobling->real_escape_string($_POST["ansatte_telefonnummer"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <form method="post">
        <input type="number" name="ansatte_telefonnummer" placeholder="Skriv inn telefonnummeret">
        <button type="submit" name="submit2">Slett ansatt</button>
    </form>
</main>
</body>
</html>