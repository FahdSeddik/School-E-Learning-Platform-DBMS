<?php
    include_once 'header.php';
    include_once 'LOGCHECK.php';
    require_once 'includes/functions.inc.php';
    require_once 'includes/dbh.inc.php';
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../dist/output.css" rel="stylesheet">
    <link rel="icon" href="assets/menu/announcement.png">
    <title>Announcements</title>
    <link href="Subjects/index.css" rel="stylesheet">
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
    <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
     
</head>
<body class='bg-gray-800'>
    <div class=' ml-72 p-4  bg-gray-800 w-auto h-100 '>
            <div class=' relative mw-100'>
            <h1 class='text-gray-400'>Announcements</h1>

        <?php
        if ($_SESSION["STUDENT"] == 0) {
            echo '<div class="d-flex ml-72" style="margin-left:23%">';
            echo '<div class="shadow card w-50">';
            echo '<h5 class="shadow card-header d-flex justify-content-center">New Announcement</h5>';
            echo '<div class="card-body " style="height:300px;width:100%">';
            echo '<form action="includes/NewAnnouncement.inc.php" method="post" style="width:100%">';
            echo '<textarea type="text" name="ann-text" placeholder="Write new post..." class="shadow p-0 border border-dark" style="height:201px;width:100%;resize: none;"></textarea>';
            echo '<button class="btn btn-info ml-50 rounded-pill" style="float:right" type="submit" name="new-ann"><h4>Post</h4></button>';
            echo '</form></div></div></div></div><div class="astrodivider" style="margin-left:30%"><div class="astrodividermask"></div><span><i>&#10038;</i></span></div>';
        }
        $ann = getAnnouncements($conn);
        foreach ($ann as $a) {
            echo '<div class="shadow card rounded-pill w-75 ml-5 " style="width:100%;height:auto">';
            echo '<div class="m-4">';
            echo "<h5 >Posted by: " . ucwords($a[0]) . "</h5>";
            echo "<p>Date: " . date_format($a[2], 'Y-m-d H:i') . " GMT+00:00</p>";
            echo "<hr><p class='ml-4 mt-0 b'>" . $a[1] . "</p>";
            echo '</div><br></div><hr>';
            
        }
        ?>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

</body>
</html>



