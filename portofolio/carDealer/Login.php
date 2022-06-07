<?php
ob_start();
session_start();
?>

<?
// error_reporting(E_ALL);
// ini_set("display_errors", 1);
?>
<!DOCTYPE html>
<html>

<head>
    <title>Login</title>
    <link rel="stylesheet" href="styles.css">
</head>

<body>
<?php include 'meny.html'?>

<div class = "container form-signin">


</div> <!-- /container -->

<div class = "container">
    <h2>Enter Username and Password</h2>
    <?php
    $msg = '';

    if (isset($_POST['login']) && !empty($_POST['username'])
        && !empty($_POST['password'])) {

        if ($_POST['username'] == 'bilforhandler' &&
            $_POST['password'] == '1234')  {
            $_SESSION['valid'] = true;
            $_SESSION['timeout'] = time();
            $_SESSION['username'] = 'Cardealer';

            echo '<p style="color: green;">Success. <a style="color: green;" href="indexET.php">Trykk her for å forsette!</a></p>';
        }else {
            $msg = 'Wrong username or password';
        }
    }
    ?>
    <form class = "form-signin" role = "form"
          action = "<?php echo htmlspecialchars($_SERVER['PHP_SELF']);
          ?>" method = "post">
        <h4 style="color: red;" ><?php echo $msg; ?></h4>
        <input type = "text" class = "form-control"
               name = "username" placeholder = "username"
               required autofocus></br>
        <input type = "password" class = "form-control"
               name = "password" placeholder = "password" required> </br>
        <button class = "btn btn-lg btn-primary btn-block" type = "submit"
                name = "login">Login</button>
    </form></br>
</div>

</body>
</html>