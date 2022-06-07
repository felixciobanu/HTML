<?php $tilkobling = mysqli_connect("localhost","root","","finbil_v3");
    $tilkobling->set_charset("utf8");
    if(isset($_POST["submit"])) {
        $sql = sprintf("INSERT INTO merke(bilmerke, model)
        VALUES('%s', '%s')",
            $tilkobling->real_escape_string($_POST["bilmerke"]),
            $tilkobling->real_escape_string($_POST["model"])
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
    <h1>Legg til nytt bilmerke:</h1>
    <form method="post">
        <input type="text" name="bilmerke" placeholder="Merke navn (f.eks. Audi)">
        <input type="text" name="model" placeholder="Model navn (f.eks. A6)"><br />
        <button name="submit" type="submit"> Legg til Merke</button>
    </form>
</main>
</body>
</html>