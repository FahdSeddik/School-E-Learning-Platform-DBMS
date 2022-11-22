<?php
    include_once '../header.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Classes</title>
    <!-- The icon -->
    <link rel="icon" href="icon.png">
    <!-- CSS file -->
    <link href="index.css" rel="stylesheet">
    
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css" integrity="sha512-MV7K8+y+gLIBoVD59lQIYicR65iaqukzvf/nwasF0nqhPay5w/9lJmVM2hMDcnK1OnMGCdVK+iQrJ7lzPJQd1w==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    
</head>
<body onload="stopload()">
<!-- <div id="loader"></div> -->
<div id="navbar" >
    <input type="checkbox" id="check">
        <label for="check">
            <i class="fas fa-bars" id="btn"></i>
            <i class="fas fa-times" id="cancel"></i>
        </label>
    <div class="sidebar">
        <header>Main Menu</header>
        <ul>
            <li><a href="index.html"><i class="fas fa-house"></i>Classes</a></li>
            <li><a href="schedule.html"><i class="fas fa-calendar-week"></i>Schedule</a></li>
            <li><a href="#"><i class="fas fa-envelope"></i>Send E-mail</a></li>
            <li><a href="#"><i class="fas fa-sliders-h"></i>Settings</a></li>
        </ul>
    </div>
</div>
<script>
        // When the user scrolls the page, execute myFunction
        window.onscroll = function() {st()};

        // Get the navbar
        var navbar = document.getElementById("navbar");

        // Get the offset position of the navbar
        var sticky = navbar.offsetTop;

        // Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
        function st() {
            if (window.pageYOffset >= sticky) {
                navbar.classList.add("sticky")
            } else {
                navbar.classList.remove("sticky");
            }
        }
</script>
    <!-- Main Div -->
    <div id="maindiv" class="animate-bottom">
        <!-- <h1>Welcome</h1> -->
            <?php
                if($_SESSION["usersName"]){
                    echo '<h1 style="z-index:0">Welcome '. $_SESSION["usersName"] . '</h1>';
                    echo '<h1 style="z-index:0">Your Mobile no.: '. $_SESSION["usersMobile"] . '</h1>';
                }
            ?>
    </div>

    










    
    <!-- Bootstrap JS requirements -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <!-- <script src="index.js"></script> -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>