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
    <title>Classes Schedule</title>
    <link rel="icon" href="assets/menu/schedule.png">

    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
        <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        
</head>
<body class='bg-gray-800'>
    <div class=' ml-72 p-4  bg-gray-800 w-auto h-100 ' >
            <div class=' relative gray'>
                <h1 class='text-gray-400'>Schedule</h1>
            </div>

            <?php
            $schedule = getSchedule($conn);
            $check=0;
            foreach($schedule as $day){
                if(count($day)>0){
                    $check=1;
                    break;
                }
            }
            if($check==1){
                $days = array('Sunday','Monday','Tuesday','Wednesday','Thursday');
                echo '<div class="card ml-50 w-75">';
                echo '<h5 class="card-header w-100">Time-Table</h5><div class="card-body">';
                
                for ($i = 0; $i < count($days);$i++){
                    echo '<hr><br>';
                    echo '<h2>' . $days[$i] . '</h2>';
                    echo '<hr>';
                    foreach ($schedule[$i] as $sub) {
                        echo '<div class="card rounded w-50 ml-5">';
                        echo '<p>Time: ' . date_format($sub[4], 'H:i') . '-' . date_format($sub[5], 'H:i') . '</p>';
                        echo '<p>Building: ' . $sub[0] . ' Floor: ' . $sub[1] . ' Room No: ' . $sub[2] . '</p>';
                        echo "<h3>".ucwords($sub[3])."</h3>";
                        echo '</div><br>';
                    }
                }
                echo '</div></div><br><br>';
            }
            ?>



    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>

</body>
</html>



