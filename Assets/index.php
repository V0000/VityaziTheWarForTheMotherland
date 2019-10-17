<?php

    require 'db.php';
    $name = $_POST['Name'];
	$pass = $_POST['Pass'];
	
	if(!isset(name) || !isset($pass))
	{
		echo 'Data is not validate!';
		exit;
	}
	echo register_user($name, $pass);

?>
