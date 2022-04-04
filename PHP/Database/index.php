
<?php
require_once 'connect.php'
?>




<!doctype html>
<html>
 <head>
  <meta charset="utf-8">
  <title>БД</title>
 </head>
 <h1>База данных склада продуктов</h1>
 <h2>Продукты                            Поставщики                                       Поставки</h2> 
 
 <style>
	div
	{
		display: flex;
	}

	th, td
	{ 
		padding: 10px;
	}
	
	th
	{
		background: #606060;
		color: #fff;
	}
	td
	{
		background: #b5b5b5;
	}
 
 </style>
 
 <body>
 
<div>
	<table  border= 1 style = "float:left;">
		<tr>
			<th>ID</th>
			<th>Name</th>
			<th>Price</th>
		</tr>
			
			<?php
		
				$query = 'SELECT * FROM product';
				$products = mysqli_query($connect, $query);
				$products = mysqli_fetch_all($products);
				foreach($products as $product)
				{
					?>
					
						<tr>
							<td><?= $product[0] ?></td>
							<td><?= $product[1] ?></td>
							<td><?= $product[2] ?></td>
						</tr>
					
					
					<?php
				}
			?>
	</table>
	
	<table border = 1 style = "margin-left: 100px">		
		<tr>
			<th>ID</th>
			<th>Name</th>
			<th>Phone</th>
		</tr>
	
			<?php
		
				$query = 'SELECT * FROM postavshik';
				$vendors = mysqli_query($connect, $query);
				$vendors = mysqli_fetch_all($vendors);
				foreach($vendors as $vendor)
				{
					?>
					
						<tr>
							<td><?= $vendor[0] ?></td>
							<td><?= $vendor[1] ?></td>
							<td><?= $vendor[2] ?></td>
						</tr>
					
					
					<?php
				}
			?>
		
	</table>

	<table border = 1 style = "margin-left: 100px">
		<tr>
			<th>Postavshik</th>
			<th>Product</th>
		</tr>
			
			<?php
		
				$query = 'SELECT pc_name, pr_name FROM postavka join product on product.pr=postavka.pr join postavshik on postavshik.pc=postavka.pc';
				$vendors = mysqli_query($connect, $query);
				$vendors = mysqli_fetch_all($vendors);
				foreach($vendors as $vendor)
				{
					?>
					
						<tr>
							<td><?= $vendor[0] ?></td>
							<td><?= $vendor[1] ?></td>	
						</tr>
					
					
					<?php
				}
			?>
	</table>			
</div>
<hr>

 </body>
 </html>