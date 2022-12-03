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

    <!-- Main Div -->
    <div id="maindiv" class="animate-bottom">
        <!-- <h1>Welcome</h1> -->
        <?php
                if($_SESSION["usersName"]){
                    echo '<h1 style="z-index:0">Welcome '. $_SESSION["usersName"] . '</h1>';
                    echo '<h1 style="z-index:0">Your Mobile no.: '. $_SESSION["usersMobile"] . '</h1>';
                }
                $sql = "SELECT Subject.sub_Num,Subject.sub_Dep_Name,Subject.sub_Name
                FROM Student,Enrollment,Subject
                Where (Student.Username = '" . $_SESSION["username"] . "' or Student.std_Email = '" . $_SESSION["username"] . "')
                AND Student.std_ID=Enrollment.std_ID AND Enrollment.sub_Num=Subject.sub_Num
                AND Enrollment.sub_Dep_Name=Subject.sub_Dep_Name";
                $connectionInfo = array("UID" => "fahdseddik", "pwd" => "CMPN202Hello", "Database" => "SchoolDBMS", "LoginTimeout" => 30, "Encrypt" => 1, "TrustServerCertificate" => 0);
                $serverName = "tcp:cmpn202-schooldbms.database.windows.net,1433";
                $conn = sqlsrv_connect($serverName, $connectionInfo);
                $stmt = sqlsrv_query($conn,$sql);
                while($row = sqlsrv_fetch_array($stmt)){
                    echo '<h3>You are registered in subject: '. $row[2] .'</h3>';
                }

            ?>
    </div>

    










    
    <!-- Bootstrap JS requirements -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="index.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>