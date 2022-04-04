<?php

	$login = filter_var(trim($_POST['login']),FILTER_SANITIZE_STRING);
	$name = filter_var(trim($_POST['name']),FILTER_SANITIZE_STRING);
	$pass = filter_var(trim($_POST['pass']),FILTER_SANITIZE_STRING);
	
	if(mb_strlen($login) < 5 || mb_strlen($login)>25){
		echo "Недопустимая длинна логина!";
		exit();
	} else if(mb_strlen($name) < 2 || mb_strlen($name)>50){
		echo "Недопустимая длинна имени!";
		exit();
	}else if(mb_strlen($pass) < 6 || mb_strlen($pass)>20){
		echo "Недопустимая длинна пароля!";
		exit();
	}
	$pass = md5($pass."roman");
	
	$mysql = new mysqli('localhost','root','','register-bd');
	
	$mysql->query("INSERT INTO `users` (`login`, `pass`, `name`) VALUES('$login','$pass','$name')");
	
	$mysql->close();
	
	header('Location: index.php');
?>