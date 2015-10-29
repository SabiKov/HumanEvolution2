<?PHP

$user = $_POST['user'];
$pass = $_POST['password'];

$con = mysql_connect("localhost","root","usbw") or ("Cannot connect!"  . mysql_error());
if (!$con)
	die('Could not connect: ' . mysql_error());
	
mysql_select_db("unitytut" , $con) or die ("could not load the database" . mysql_error());

$check = mysql_query("SELECT * FROM unitytut WHERE `user`='".$user."'");
$numrows = mysql_num_rows($check);
if ($numrows == 0)
{
	die ("Username does not exist \n");
}
else
{
	//$pass = md5($pass); 
	while($row = mysql_fetch_assoc($check))
	{
		if ($pass == $row['pass'])
			die("login-SUCCESS");
		else
			die("Password does not match \n");
	}
}

?>