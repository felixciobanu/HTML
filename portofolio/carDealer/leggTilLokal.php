<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
if(isset($_POST["submit"])) {
    $sql = sprintf("INSERT INTO lokale(id, sted, email, adresse)
VALUES('%s', '%s','%s','%s')",
        $tilkobling->real_escape_string($_POST["id"]),
        $tilkobling->real_escape_string($_POST["sted"]),
        $tilkobling->real_escape_string($_POST["email"]),
        $tilkobling->real_escape_string($_POST["adresse"])
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
    <h1>Legg til et nytt lokal</h1>
    <form method="post">
        <input type="number" name="id" placeholder="Legg til id">
        <input type="text" name="sted" placeholder="Legg til navn på sted">
        <input type="text" name="email" placeholder="Legg til email til bedriften">
        <input type="text" name="adresse" placeholder="Legg til adresse">
        <button type="submit" name="submit">Legg til lokale</button>
    </form>
<?php
    $sql = "Select * 
    From finbil_v3.lokale;";
    $datasett = $tilkobling->query($sql);
?>
    <h1>Her er dine lokaler:</h1>
    <table>
        <tr>
            <th>Id</th>
            <th>Navn</th>
            <th>Email</th>
            <th>Adresse</th>
        </tr>
        <?php while($rad = mysqli_fetch_array($datasett)) { ?>
            <tr>
                <td><?php echo $rad["id"]; ?></td>
                <td><?php echo $rad["sted"]; ?></td>
                <td><?php echo $rad["email"]; ?></td>
                <td><?php echo $rad["adresse"]; ?></td>
            </tr>
        <?php } ?>
    </table>
    <?php
    if(isset($_POST["submit2"])) {
        $sql = sprintf("DELETE FROM `finbil_v3`.`lokale` WHERE (`id` = '%s');",
            $tilkobling->real_escape_string($_POST["id"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <h1>Slett et lokal:</h1>
    <form method="post">
        <input type="number" name="id" placeholder="Legg til id">
        <button type="submit" name="submit2">Slett lokale</button>
    </form>
</main>
</body>
</html>