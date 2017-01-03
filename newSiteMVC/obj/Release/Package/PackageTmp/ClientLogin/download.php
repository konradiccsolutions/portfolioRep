<?php

	require_once('auth.php');



	 if (strtotime($_SESSION['SESS_EXPIRYDATE']) < time()) {

	   echo "<p>Expired! ".date("d F Y", strtotime($_SESSION['SESS_EXPIRYDATE']))."</p>";

?>

<script language="javascript">

location.href="expired.php";

</script>

<?php

	 }



	//Include database connection details

	require_once('config.php');

	

	//Array to store validation errors

	$errmsg_arr = array();

	

	//Validation error flag

	$errflag = false;

	

	//Connect to mysql server

	$link = mysql_connect(DB_HOST, DB_USER, DB_PASSWORD);

	if(!$link) {

		die('Failed to connect to server: ' . mysql_error());

	}

	

	//Select database

	$db = mysql_select_db(DB_DATABASE);

	if(!$db) {

		die("Unable to select database");

	}



	$ID = $_GET['ID'];  //gets ID from url line

	

	//Create query

	$qry="SELECT Ownership.ProdID,Products.Filename,Products.Version FROM Ownership INNER JOIN Products ON Ownership.ProdID=Products.ProdID WHERE Products.ID='".$ID."' AND CustID = '".$_SESSION['SESS_CUST_ID']."'";

	$result=mysql_query($qry);

	

	//Check whether the query was successful or not

	if($result) {

		if(mysql_num_rows($result) != 0) {

			$row = mysql_fetch_array($result);



			$strFileURL ="../../updates/".$row['Filename'];

			if (!file_exists($strFileURL)) {

			   // file is missing, so no attempt to download. pop up message

			   ?> <script language="javascript">alert('File <?=basename($strFileURL)?> missing.\r\nPlease contact support@iccsolutions.com'); location.href="cliprods.php"; </script>"; <?php

			   exit();

			}

			

			$downloadqry = "SELECT * FROM Downloads WHERE CustID = '".$_SESSION['SESS_CUST_ID']."' AND ProdID='".$row['ProdID']."';";

			$dlresult = @mysql_query($downloadqry) or die("Query failed: " . mysql_error()); 

			if($dlresult) {

			   if(mysql_num_rows($dlresult) == 0) {

			     // no downloads found for this user & product

        		 $query = "INSERT INTO Downloads(CustID, ProdID, Version, DldAttempts, LastDldTime) VALUES ('".$_SESSION['SESS_CUST_ID']."', '".$row['ProdID']."', '".$row['Version']."', 1, NOW())";

				 $qresult = @mysql_query($query) or die("Query failed: " . mysql_error()); 

			   } else {

			     // already downloaded at least once

			     $dlrow = mysql_fetch_array($dlresult);

				 $dldattempts = $dlrow['DldAttempts'];

				 $dldattempts++;

        	     $query = "UPDATE Downloads set DldAttempts=".$dldattempts.", LastDldTime=NOW() WHERE CustID = '".$_SESSION['SESS_CUST_ID']."' AND ProdID='".$row['ProdID']."';";

				 $qresult = @mysql_query($query) or die("Query failed: " . mysql_error()); 

			   }

			}

			

			//stream file

    		header('Pragma: public');

    		header('Content-Description: File Transfer');

    		header('Content-Type: application/octet-stream');

    		header('Expires: 0');

    		header('Cache-Control: must-revalidate, post-check=0, pre-check=0');

			header('Content-Disposition: attachment; filename="'.basename($strFileURL).'"');

			header("Content-Transfer-Encoding: binary");

			header("Content-Length: ".filesize($strFileURL));

			ob_clean();

			flush();

			readfile("$strFileURL");

			exit();

		} else {

		    // no rows - so failed to find. redirect back to cliprods page

			header("cliprods.php");

		}

	}



?>