<?php
    include_once 'header.php';
    include_once 'LOGCHECK.php';
    require_once 'includes/functions.inc.php';
    require_once 'includes/dbh.inc.php';
    if(!isset($_SESSION["sender"])){
        header("location: Contact.php?error=FORM_NOT_SUBMITTED");
        exit();
    }
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../dist/output.css" rel="stylesheet">
    <link rel="icon" href="assets/menu/communicate.png">
    <title>Contact</title>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
    <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
     
</head>
<body class='bg-gray-800'>
<div class=' ml-72 p-4  bg-gray-800 w-auto h-100 '>
            <div class=' relative mw-100'>
            <h1 class='text-gray-400'>Contact</h1>

    <?php 
        echo '<div class="d-flex" style="">';
        echo '<div class="shadow card w-100">';
        echo '<h5 class="shadow card-header d-flex justify-content-center">New Request</h5>';
        echo '<div class="card-body " style="height:auto;width:100%">';
        echo '<form action="includes/send_request.php" method="post" style="width:100%">';
        echo "<h4>Send to:</h4><select title='send_requests' Name='send-to' class='border'>";
        echo '<option value="'.$_SESSION["sender"].'">TO REPLY</option> '; 
        echo '</select>';
        echo "<h4>Status:</h4>";
        echo "<select title='state' name='state' class='border'>";
        echo '<option value="">---SELECT---</option> '; 
        echo '<option value="1">Approved</option> '; 
        echo '<option value="0">Denied</option> '; 
        echo '</select><br><hr>';
        echo '<input type="text" name="title" placeholder="Request Title" class="shadow mb-2 border border-dark" style="width:50%;resize: none;">';
        echo '<textarea type="text" name="request-text" placeholder="Write request..." class="shadow p-0 border border-dark" style="height:201px;width:100%;resize: none;"></textarea>';
        echo '<button class="btn btn-info ml-50 rounded-pill" style="float:right" type="submit" name="new-reply"><h4>Reply</h4></button>';
        echo '</form></div></div></div><div class="astrodivider" style="margin-left:30%"><div class="astrodividermask"></div><span><i>&#10038;</i></span></div>';
        

    ?>
</div>
</div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="index.js"></script>

</body>
</html>



