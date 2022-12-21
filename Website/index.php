<?php
  include_once './src/header.php';
?>

<section class="login-form" style="margin-top:150px">
    <h2>Login</h2>
    <form action="./src/includes/login.inc.php" method="post">
        <input type="text" name="uid" placeholder="Username/Email...">
        <input type="password" name="pwd" placeholder="Password...">
        <button type="submit" name="submit">Login</button>
    </form>

    
    <?php
    if(isset($_GET["error"])){
        if($_GET["error"] == "emptyinput"){
            echo "<p>Fill in all field!</p>";
        }
        else if($_GET["error"] == "wronglogin"){
            echo "<p>Incorrect login credentials!</p>";
        }else {
            echo "<p>Unkown Error Occurred</p>";
        }
    }
?>
</section>


