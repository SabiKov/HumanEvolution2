<?PHP

$user = $_POST['user'];
$name = $_POST['name'];
$pass = $_POST['password'];

$con = mysql_connect("localhost","root","usbw") or ("Cannot connect!"  . mysql_error());
if (!$con)
	die('Could not connect: ' . mysql_error());
	
mysql_select_db("unitytut" , $con) or die ("could not load the database" . mysql_error());

$check = mysql_query("SELECT * FROM unitytut WHERE `user`='".$user."'");
$numrows = mysql_num_rows($check);
if ($numrows == 0)
{
	//$pass = md5($pass);
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