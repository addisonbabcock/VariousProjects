<?php
session_start ();

echo "<html>";
echo "<head><title>Log in complete maybe</title></head>";
echo "<body>";

$_SESSION ['status'] = 0;
$_SESSION ['username'] = $usern;
$_SESSION ['password'] = $passw;

/* Connecting, selecting database */
$link = mysql_connect("localhost", "rmwin8h3", "l0lWUT")
	or die("Could not connect");
//print "My GuestBook - Connected successfully<br>";
mysql_select_db("rmwin8h3_maintLog") or die("Could not select database");

/* Performing SQL query */
$query = "SELECT * FROM users WHERE username='$usern' AND password='$passw'";
$result = mysql_query($query) or die("Query failed");

//get the first result
$line = mysql_fetch_array($result, MYSQL_ASSOC);

if ($line)
{
	$_SESSION ['status'] = $line ['priviledges'];
	echo "<h1>You are logged in and may proceed.</h1><br>\n";
	
	if ($_SESSION ['status'] >= 1)
	{
		echo "<a href='../guestbook_ica2/index.html'>View Guestbook</a> ";
		echo "<a href='../maintLog/viewLog.php'>View Maintenance Log</a> ";
	}
	
	if ($_SESSION ['status'] >= 2)
	{
		echo "<a href='../php_ica/index.html'>Run Mode</a> ";
	}
}

if ($_SESSION ['status'] == 0)
{
	echo "<h1>You could not be logged in. Please <a href='finalproj.html'>try again.</a></h1>";
	session_destroy ();
}
echo "</body></html>";

mysql_free_result ($result);
?>