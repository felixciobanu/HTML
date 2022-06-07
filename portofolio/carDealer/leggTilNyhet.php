<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
$tilkobling->set_charset("utf8");
if(isset($_POST["submit"])) {
    $sql = sprintf("INSERT INTO nyheter(tittel, innhold, bildeadresse, lokale)
VALUES('%s', '%s','%s','%s')",
        $tilkobling->real_escape_string($_POST["tittel"]),
        $tilkobling->real_escape_string($_POST["innhold"]),
        $tilkobling->real_escape_string($_POST["bildeadresse"])
    );
    $tilkobling->query($sql);
}
$sql = "SELECT id, sted
    FROM lokale";
$datasett = $tilkobling->query($sql);

?>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<?php include "meny2.html" ?>
<main id="main1">
    <h1>Legg til en nyhet</h1>
    <form method="post">
        <input name="tittel" placeholder="Legg til Tittel">
        <textarea name="innhold" placeholder="Legg til innhold"></textarea>
        <input type="text" name="bildeadresse" placeholder="Legg til bildeadresse">
        <button type="submit" name="submit">Legg til lokale</button>
    </form>

    <?php
    $sql = "Select * 
    From finbil_v3.nyheter;";
    $datasett = $tilkobling->query($sql);
    ?>
    <h1>Her er dine nyhetsartikler:</h1>
    <table>
        <tr>
            <th>Id</th>
            <th>tittel</th>
            <th>innholdet</th>
            <th>bildedresse</th>
            <th>Opplastningsdato</th>
        </tr>
        <?php while($rad = mysqli_fetch_array($datasett)) { ?>
            <tr>
                <td><?php echo $rad["id"]; ?></td>
                <td><?php echo $rad["tittel"]; ?></td>
                <td><?php echo $rad["innhold"]; ?></td>
                <td><?php echo $rad["bildeadresse"]; ?></td>
                <td><?php echo $rad["opplastningsdato"]; ?></td>
            </tr>
        <?php } ?>
    </table>
    <?php
    if(isset($_POST["submit2"])) {
        $sql = sprintf("DELETE FROM `finbil_v3`.`nyheter` WHERE (`id` = '%s');",
            $tilkobling->real_escape_string($_POST["id"])
        );
        $tilkobling->query($sql);
    }
    ?>
    <h1>Slett en nyhetsartikkel:</h1>
    <form method="post">
        <input type="number" name="id" placeholder="Legg til id">
        <button type="submit" name="submit2">Slett lokale</button>
    </form>
</main>

</body>
</html>