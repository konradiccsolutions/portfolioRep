<?php

	require_once('auth.php');

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<HEAD>

<TITLE>Products owned by Client</TITLE>

<style type="text/css">



.style1 {

	font-family: Arial, Helvetica, sans-serif;

}



.style2 {



				font-family: Arial, Helvetica, sans-serif;



				font-weight: bold;



				font-size: small;



				color: #012346;



}



.style3 {

	font-size: small;

}



.style5 {

	font-size: small;

	color: #012346;

}



.style6 {



				font-family: Verdana;



				font-size: small;



				color: #012346;



}



.style7 {



				color: #012346;



}



.style8 {

	font-family: Arial, Helvetica, sans-serif;

	font-size: small;

	color: #012346;

}

.style9 {

	font-family: Arial, Helvetica, sans-serif;

	font-size: small;

}



.style10 {

	border-left-style: none;

	border-left-width: medium;

	border-right-style: none;

	border-right-width: medium;

	border-bottom-style: none;

	border-bottom-width: medium;

}

.style11 {

	border-left-width: 0px;

	border-right-width: 0px;

	border-bottom-width: 0px;

}



.auto-style1 {
	color: #808080;
}
.auto-style3 {
	font-family: Arial, Helvetica, sans-serif;
	font-size: small;
	color: #808080;
	text-align: center;
}
.auto-style5 {
	font-family: Arial, Helvetica, sans-serif;
	font-weight: bold;
	font-size: small;
	color: #808080;
}
.auto-style6 {
	text-align: center;
}



</style>

</head>



<body>

   <div id="wrapper">

   

         <div align="center">



			<table cellspacing="0" cellpadding="0" border=0 bordercolor="#ffffff" class="style11">

        

<!-- end of new frameset section -->



  				<tr>

					<td style="vertical-align: top; " width="922" class="style10">

					<div style="margin: 10px;" class="style7">





<span class="style9">





<?php

	 if (strtotime($_SESSION['SESS_EXPIRYDATE']) < time()) {

	   echo "<p>Expired! ".date("d F Y", strtotime($_SESSION['SESS_EXPIRYDATE']))."</p>";

?></span> <span class="style1"><span class="style3">

<script language="javascript">

location.href="expired.php";

</script>

<?php

	 }

	 echo "<H2>Products Registered to ".$_SESSION['SESS_FULL_NAME']."</H2>";



	 if (strtotime($_SESSION['SESS_EXPIRYDATE']) < strtotime("+7 days")) {

	   echo "<p class=boxed><b>Please Note:</b> Your support period will expire on ".date("d F Y", strtotime($_SESSION['SESS_EXPIRYDATE']))."</p>";

	 }

	 echo "<p>The following product(s) have been registered to ".$_SESSION['SESS_FULL_NAME'].".</p>";



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



	//Create query

	$qry="SELECT * FROM Ownership WHERE CustID = '".$_SESSION['SESS_CUST_ID']."'";

	$result=mysql_query($qry);

	

	//Check whether the query was successful or not

	if($result) {

		if(mysql_num_rows($result) != 0) {

			echo "<div align=center><table class=prodtable><tr><th width='45%'>Product</th>";

			echo "<th width='15%' class=ctr>Version</th><th width='25%' class=ctr>Downloads</th><th width='15%' class=ctr>ZIP Password</th></tr>";



			$colour = "FFFFFF";

			while ($row = mysql_fetch_array($result)) {

				  $prod_id = $row['ProdID'] ;

				  $show_until_date = $row['ShowUntilDate'];

				  $expiry_date = $row['ExpiryDate'];



				  $prodqry="SELECT * FROM Products WHERE ProdID = '".$prod_id."'";

				  $prodresult=mysql_query($prodqry);

				  $prodrow=mysql_fetch_array($prodresult);



				  $strProdName = $prodrow['Name'];

				  $strVersion = $prodrow['Version'];

				  $strFileName = $prodrow['Filename'];

				  $strURL = "download.php?ID=".$prodrow['ID'];

				  $strPass = $prodrow['Password'];



				  if ($expiry_date == "0000-00-00 00:00:00") {

				  	 echo "<TR style='background-color:#".$colour.";'><TD>".$strProdName."</TD><TD style='text-align:center'>".$strVersion."</TD>";

					 echo "<TD style='text-align:center'><a href='".$strURL."'>".$strFileName."</a></td><td style='background-color:#".$colour.";text-align:center'>".$strPass."</td></tr>";

				  } else {

				  	 if (strtotime($expiry_date) < time()) {

				  	 	echo "<TR style='background-color:#".$colour.";'><TD>".$strProdName."</TD><TD style='text-align:center'>".$strVersion."</TD>";

                        echo "<TD style='background-color:#".$colour.";text-align:center' colspan=2><B><I>Support Expired</I></B></TD></tr>";

					 } else {

				  	    echo "<TR style='background-color:#".$colour.";'><TD>".$strProdName."</TD><TD style='text-align:center'>".$strVersion."</TD>";

                        echo "<TD style='text-align:center'><a href='".$strURL."'>".$strFileName."</a></td><td style='background-color:#".$colour.";text-align:center'>".$strPass."</td></tr>";

					 }

				  }

				  if ($colour == "FFFFFF") {

				  	 $colour = "E0E0E0";

				  } else {

				  	 $colour = "FFFFFF";

				  }

			}

			echo "</table></div>";

		}else {

			echo "<p>No Products for this Customer</p>";

		}

	}else {

		die("Query failed");

	}

?></span></span>



				<p class="auto-style3">To download the latest update, click on the highlighted link.</p>

<p class="auto-style3"><strong>Please refer to the password next to the download to unzip the 

				file.</strong></p>

<p class="auto-style3">Instructions for installation and usage will be in your update email.</p>

				<p class="auto-style6"><span class="auto-style5">Please Note:</span><span class="style1"><span class="style3"><span class="auto-style1"> Downloads are packaged as zip files.</span></span></span></p>						<p class="auto-style6"><span class="style1">						<span class="style3"><span class="auto-style1"> You will need to use WinZip, or a similar product to

extract and install the update.</span></span></span></p>

					</div></td>

				</tr>

			</table>

			</div>

<script language=javascript>

	parent.window.document.title = "ICC Solutions Client Product Updates"

</script>

   </div>

   <!-- End Wrapper -->

</BODY>

</HTML>