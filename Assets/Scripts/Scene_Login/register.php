<?PHP

$user = $_POST['user'];
$name = $_POST['name'];
$pass = $_POST['password'];

$Hostname = "localhost";
$DBName = "accounts";
$User = "root";
$PasswordP = "usbw"; 

mysql_connect($Hostname,$User,$Password)or die("can not connect to DB");
mysql_select_db($DBName) or die("cant connect to DB");

$check = mysql_query("SELECT * FROM unitytut WHERE `user`='".$user."'");
$numrows = mysql_num_rows($check);
if ($numrows == 0)
{
	$pass = md5($pass);
	$ins = mysql_query("INSERT INTO  `unitytut` (  `id` ,  `user` ,  `name` ,  `pass` ) VALUES ('' ,  '".$user."' ,  '".$name."' ,  '".$pass."') ; ");
	if ($ins)
		die ("Succesfully Created User!");
	else
		die ("Error: " . mysql_error());
}
else
{
	die("User allready exists!");
}


?>