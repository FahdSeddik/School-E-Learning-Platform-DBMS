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
        echo '<option value="">--- Select ---</option> '; 
        $tolist = array();
        if($_SESSION["STUDENT"]){
            $tolist = getTeachers($conn);
        }
        foreach($tolist as $send){
            echo '<option value="'.$send[0].'">';
            echo '<p>'.ucwords($send[1]).'</p>';
            echo '<p>, '.$send[2].'</p>';
            echo '</option>';
        }
        $tolist = getAdmins($conn);
        foreach($tolist as $send){
            echo '<option value="'.$send[0].'">';
            echo '<p>'.ucwords($send[1]).'</p>';
            echo '<p>, '.$send[2].'</p>';
            echo '<p>, ' . $send[3] . '</p>';
            echo '</option>';
        }
        echo '</select><br><hr>';
        echo '<input type="text" name="title" placeholder="Request Title" class="shadow mb-2 border border-dark" style="width:50%;resize: none;">';
        echo '<textarea type="text" name="request-text" placeholder="Write request..." class="shadow p-0 border border-dark" style="height:201px;width:100%;resize: none;"></textarea>';
        echo '<button class="btn btn-info ml-50 rounded-pill" style="float:right" type="submit" name="new-request"><h4>Send</h4></button>';
        echo '</form></div></div></div>';
        

    ?>

    <h1 class='text-gray-400'>Inbox</h1>

    <?php
        $inbox = getInbox($conn);
        $i = 0;
        for($j = 0;$j<count($inbox);$j++){//staff name , staff email, title , request,state, date, sender
            if($inbox[$j][4]==-1){
                echo '<div class="shadow card rounded-pill w-75 ml-5 bg-secondary" style="display:flex;width:100%;height:auto">';
                echo '<h5>State: Pending</h5>';
            }else if($inbox[$j][4]==1){
                echo '<div class="shadow card rounded-pill w-75 ml-5 bg-success" style="width:100%;height:auto">';
                echo '<h5>State: Approved</h5>';
            }else{
                echo '<div class="shadow card rounded-pill w-75 ml-5 bg-danger" style="width:100%;height:auto">';
                echo '<h5>State: Denied</h5>';
            }
            echo '<div class="shadow card rounded-pill w-75 ml-5 mb-3" style="width:100%;height:auto">';
            echo '<div class="m-4">';
            echo "<h5 >Title: ".$inbox[$j][2]."</h5>";
            echo "<h5 >From: ".ucwords($inbox[$j][0]).", " . $inbox[$j][1] . "</h5>";
            echo "<p>Date: " . date_format($inbox[$j][5], 'Y-m-d') . "</p>";
            echo "<hr><p class='ml-4 mt-0 b'>" . nl2br($inbox[$j][3]) . "</p>";
            echo '</div><br></div>';
            echo '<form action="includes/handle_request.php" method="post">';
            echo '<input type="hidden" name="sender'.$i.'" value="'.$inbox[$j][6].'">';
            echo '<input type="hidden" name="receiver'.$i.'" value="'.$_SESSION["SSN"].'">';
            echo '<input type="hidden" name="title'.$i.'" value="'.$inbox[$j][2].'">';
            echo '<input type="hidden" name="request'.$i.'" value="'.$inbox[$j][3].'">';
            echo '<input type="hidden" name="state'.$i.'" value="'.$inbox[$j][4].'">';
            echo '<input type="hidden" name="date'.$i.'" value="'.date_format($inbox[$j][5], 'Y-m-d').'">';
            echo '<button class="btn btn-danger w-25 rounded-pill border border-dark shadow" style="float:left" type="submit" name="delete-request'.$i.'"><h4>Delete</h4></button>';
            if(count($inbox[$j]) >= 10){
                if ($_SESSION["STUDENT"] == 0 && $inbox[$j][4]==-1) {
                    echo '<button class="btn btn-info w-25 rounded-pill border border-dark shadow" style="float:right;align:right;margin-left: auto;margin-right: 0;" type="submit" name="reply-request' . $i . '"><h4>Reply</h4></button>';
                }
            }
            echo '</form>';
            echo '</div><hr>';
            $i++;
        }
    ?>
</div>
</div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="index.js"></script>

</body>
</html>



