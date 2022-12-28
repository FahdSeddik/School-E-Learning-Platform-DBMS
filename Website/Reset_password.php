<?php
  include_once './src/header.php';
  if(!isset($_SESSION["username"])){
    header("location: src/includes/logout.inc.php");
    exit();
  }
?>



<!DOCTYPE html>
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Reset Password</title>
    <link rel="icon" href="src/assets/School_Logo.png">
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v3.0.6/css/line.css">
    <link rel="stylesheet" href="	https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
       <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
<style>
    #auth #auth-right {
        
        height: 100%;
    }
    #auth #auth-left .auth-title {
        font-size: 3rem;
        margin-bottom: 1rem;
    }
    #auth #auth-left .auth-subtitle {
        color: #a8aebb;
        font-size: 1.2rem;
        line-height: 2.5rem;
    }
    .btn-gold {
        background-color: #cfab5c;
        --bs-btn-border-color: #d09b15;
        color:white
    }
        .btn-gold:hover {
            background-color: #c39e4f;
            --bs-btn-border-color: #d09b15;
            color: white
        }
        html, body {
    max-width: 100%;
    overflow-x: hidden;
    overflow-y:hidden;
}
</style></head>

<body>
    <div id="auth">

        <div class="row h-100">
            <div class="col-lg-5 col-12">
                <div id="auth-left" style="padding: 2rem 8rem">

                    <div class="auth-logo text-center mb-0">
                        
                        <img src="src/assets/School_Logo.png" alt="Logo" style="height: 13rem;">
                    </div>
                    <h3 class="auth-title text-center">Password Reset</h3>
                    <p class="auth-subtitle text-center mb-3">Please reset your password</p>

<form action="src/includes/reset_password.inc.php" class="form-horizontal" method="post" role="form">                        <div class="form-group position-relative has-icon-left mb-4">
                            <input class="form-control form-control-xl" name="new-pwd" placeholder="New Password" type="password" value=""><br>
                            <input class="form-control form-control-xl" name="confirm-pwd" placeholder="Confirm Password" type="password" value="">
                            
                        </div>
                        <?php
                        if(isset($_GET["error"])){
                            if($_GET["error"] == "PASS_NOT_UPDATED"){
                                echo '<span class="field-validation-error text-danger" data-valmsg-for="Email" data-valmsg-replace="true">PASS NOT UPDATED!</span>';
                            }else if($_GET["error"]=="PASS_TOO_WEAK"){
                                echo '<span class="field-validation-error text-danger" data-valmsg-for="Email" data-valmsg-replace="true">PASS TOO WEAK!</span>';
                                if(isset($_GET["l"])){
                                    echo '<br><span class="field-validation-error text-danger" data-valmsg-for="Email" data-valmsg-replace="true">Password length must be atleast 8 characters.</span>';
                                }
                                if(isset($_GET["d"])){
                                    echo '<br><span class="field-validation-error text-danger" data-valmsg-for="Email" data-valmsg-replace="true">Do not enter default password.</span>';
                                }
                            }else if($_GET["error"]=="NO_MATCH"){
                                echo '<br><span class="field-validation-error text-danger" data-valmsg-for="Email" data-valmsg-replace="true">Passwords do not match.</span>';
                            }
                        }
                        ?>
                        
                        <input type="submit" value="Reset password" class="btn btn-primary btn-block btn-lg shadow-lg mt-3" name="submit">
</form>                    <div class="text-center mt-3 text-lg fs-5">
                        <!-- <p><a class="font-bold" href="#">Forgot password?</a></p> -->
                    </div>
                </div>
            </div>
            
            <div class="col-lg-7 d-none d-lg-block">
                    <div id="auth-right">
                        <div class="row">
                            <div class="col-12 text-center auth-logo text-center">
                                <img src="bg.gif" style=" width: 150%;" alt="Logo">
                            </div>
                            
                        </div>
                       
                    </div>
                </div>
        </div>
    </div>




</body></html>