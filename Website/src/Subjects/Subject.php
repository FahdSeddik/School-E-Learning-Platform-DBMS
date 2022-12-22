<?php
    include_once '../header.php';
    include_once 'handleSubject.inc.php';
    require_once '../includes/functions.inc.php';
    require_once '../includes/dbh.inc.php';
    if(!isset($_GET["Dep"]) || !isset($_SESSION["username"])){
        header("location: ../Dashboard.php");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="../../dist/output.css" rel="stylesheet">
        <!-- <link href="index.css" rel="stylesheet"> -->
        <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
        <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <title><?php echo ucfirst($_GET["Dep"])?></title>  
        
    </head>
    <body>
        <?php
        $_SESSION["sub_Num"] = $_GET["num"];
        $_SESSION["sub_Dep_Name"] = $_GET["Dep"];
        ?>
        <div class=' ml-72' >
            <div class=' relative '>
            <div class="card">
                <h5 class="card-header">New Post</h5>
                <div class="card-body">
                <form action='NewPost.inc.php' method="post">
                    <textarea type="text" name="post-text" placeholder="Write new post..." class="p-0 w-50" style="resize: none;"></textarea>
                    <button class="btn btn-primary" type="submit" name="new-post">Post</button>
                </form> 
                </div>
                </div>
            <hr>
            
            <?php
            $posts = getPosts($conn);
            foreach ($posts as $post) {
                echo '<div class="card rounded w-50">';
                echo "<h6>Posted by: " . $post[2] . "</h6>";
                echo "<p>Date: " .date_format($post[1], 'c'). "</p>";
                echo "<h2 class='mt-0 b'>" . $post[0] . "</h2>";
                echo '<br></div><br><br><hr><br><br>';
            }
            ?>
            </div>
        </div>
         







        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script type="text/javascript"src="script.js"></script>
    </body>
</html>