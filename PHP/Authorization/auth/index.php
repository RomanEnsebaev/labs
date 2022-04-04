<!DOCTYPE html>
<html lang = "ru">
<head>
	<meta charset = "UTF-8">
	<title>Autorisation</title>
	<link rel="stylesheet"  href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
	<div class = "container mt-4">
	
	<?php
	
		if($_COOKIE['user']==''):
	
	?>
		<div class ="row">
		<div class ="col">
				<h1>Registration form</h1>
				<br>
				<form  action = "check.php" method = "post">
					<input type="text" class="form-control" name="login" id="login" placeholder="Pick a login"><br>
					<input type="text" class="form-control" name="name" id="name" placeholder="Enter your name"><br>
					<input type="text" class="form-control" name="pass" id="pass" placeholder="Pick a password"><br>
					<button class = "btn btn-success" type="submit">Registration</button><br>
				</form>
			</div>
			<div class ="col">
				<h1>Autorisation form</h1>
				<br>
				<form  action = "auth.php" method = "post">
					<input type="text" class="form-control" name="login" id="login" placeholder="Pick a login"><br>
					<input type="text" class="form-control" name="pass" id="pass" placeholder="Pick a password"><br>
					<button class = "btn btn-success" type="submit">Autorisation</button><br>
				</form>
			</div>
		</div>
	<?php else: ?>	
		<p>Hello, <?=$_COOKIE['user']?>. For exit press <a href="/exit.php">this</a>.</p>
	<?php endif; ?>
	</div>

	

</body>
</html>