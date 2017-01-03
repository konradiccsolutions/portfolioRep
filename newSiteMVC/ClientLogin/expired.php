<?php

	require_once('auth.php');

?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"> 

<HEAD>

<TITLE>Support Period has Expired</TITLE>

		<link rel="stylesheet" type="text/css" media="screen" href="rw_common/themes/atlas/styles.css" />
		<link rel="stylesheet" type="text/css" media="all" href="rw_common/themes/atlas/css/colourtag.css" />
		<link rel="stylesheet" type="text/css" media="screen" href="rw_common/themes/atlas/css/font/verdana.css" />				

	<script type="text/javascript" src="stmenu.js"></script>

<style fprolloverstyle>a:hover      { color: #FF0000; font-weight: bold }



</style>

<style type="text/css">

.style1 {

				font-family: Arial, Helvetica, sans-serif;

				color: #012346;

				border-style: none;

				border-width: medium;

}

.style2 {

				border-width: 0px;

}

.style4 {

				text-align: center;

}

.style5 {

				text-align: center;

				font-size: small;

}

.auto-style1 {
	color: #808080;
}
.auto-style3 {
	text-decoration: none;
}

.auto-style4 {
	border-width: 0px;
	text-align: center;
}

</style>

</head>



<body>

   <div class="style4">

   <!-- Begin Wrapper -->

   <div id="wrapper" class="style4">

   

         <!-- Begin Header -->

		 <!-- End Header -->

<!-- Stacks v1 --><div id='stacks_out_14_page17' class='stacks_top'><div id='stacks_in_14_page17' class='stacks_in'><div id='stacks_out_13_page17' class='stacks_out'><div id='stacks_in_13_page17' class='stacks_in'>
<div class="flex-container" id="1_4_6">
    
    <!-- .flexslider -->
</div><!-- .flex-container -->
</div></div><div id='stacks_out_608_page17' class='stacks_out'><div id='stacks_in_608_page17' class='stacks_in'><!-- PageLime v2.3.2 Copyright @2010-2012 Joe Workman -->


<body bgcolor="#FFFFFF" text="#666666" marginwidth="0" marginheight="0" link="#0B557F" vlink="#666666" 



alink="#CC9900">



<!-- outer table to replicate old frameset -->



<div align="center">



<table cellspacing="0" cellpadding="0" border=0 bordercolor="#ffffff" class="auto-style4">

        

<!-- end of new frameset section -->



  <tr>

      <td style="vertical-align: top; " bordercolor="#666666" class="style1">

	  <div style="margin: 10px;" class="style4">





<script language=javascript>

	parent.window.document.title = "Your Support Period has Expired"

</script>



<H2 class="style4"><span class="auto-style1">Support Period Expired</H2>

<?php

	   echo "<p>Your support period expired on ".date("d F Y", strtotime($_SESSION['SESS_EXPIRYDATE']))."</p>";

?>



<p class="style5">Please contact
<a class="auto-style3" href="http://www.iccsolutions.com/about/contact/index.php" target="_top">
<span class="auto-style1"><strong>ICC Solutions</strong></span></a> to extend your support period.</span></p>

<!-- Begin PHP Live! HTML Code -->
<span id="phplive_btn_1376916604" onclick="phplive_launch_chat_1(0)" style="color: #0000FF; text-decoration: underline; cursor: pointer;"></span>
<script type="text/JavaScript">
(function() {
	var phplive_e_1376916604 = document.createElement("script") ;
	phplive_e_1376916604.type = "text/javascript" ;
	phplive_e_1376916604.async = true ;
	phplive_e_1376916604.src = "//www.iccsolutions.com/phplive/js/phplive_v2.js.php?v=1|1376916604|0|" ;
	document.getElementById("phplive_btn_1376916604").appendChild( phplive_e_1376916604 ) ;
})();
</script>
<!-- End PHP Live! HTML Code -->
</div>

</td>

</tr>

</table>



</div>



	   </div>



</BODY>

</HTML>