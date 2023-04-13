<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="Sports.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Fan</title>
    <meta name="viewport" content="initial-scale = 1.0, maximum-scale = 1.0, user-scalable = no, width = device-width">

    <!--[if lt IE 9]><script src="https://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    <link rel="stylesheet" href="style.css" media="screen">
    <!--[if lte IE 7]><link rel="stylesheet" href="style.ie7.css" media="screen" /><![endif]-->
    <link rel="stylesheet" href="style.responsive.css" media="all">

    <style>.art-content .art-postcontent-0 .layout-item-0 { color: #B2B2B2; background: #5A9F46; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-1 { color: #B2B2B2; background: #4C84A9; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-2 { color: #B2B2B2; background: #3B6C91; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-3 { padding: 15px;  }
.art-content .art-postcontent-0 .layout-item-4 { color: #B2B2B2; background: #1C3F5A; padding: 15px;  }
.ie7 .art-post .art-layout-cell {border:none !important; padding:0 !important; }
.ie6 .art-post .art-layout-cell {border:none !important; padding:0 !important; }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="art-main">
<header class="art-header">


    <div class="art-shapes">

            </div>
<h1 class="art-headline" data-left="6.85%">
    <a href="#">Champions League</a>
</h1>
<h2 class="art-slogan" data-left="11.11%">The Stadium Is Your Home</h2>

                    
</header>
<div class="art-sheet clearfix">
            <div class="art-layout-wrapper">
                <div class="art-content-layout">
                    <div class="art-content-layout-row">
                        <div class="art-layout-cell art-content"><article class="art-post art-article">
                                
                                                
                <div class="art-postcontent art-postcontent-0 clearfix"><div class="art-content-layout">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-0" style="width: 32%" >
        <h4>Available Matches</h4>
         <img width="310" height="197" alt="" class="art-lightbox" src="images/match.jpg">
    </div><div class="art-layout-cell layout-item-1" style="width: 35%" >
        <h4>Bought Tickets</h4>
         <img width="306" height="196" alt="" class="art-lightbox" src="images/ticket.jpg">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </div>
        <div class="art-layout-cell layout-item-2" style="width: 33%" >
        <h4>Purchase Tickets</h4>
         <img width="296" height="198" alt="" class="art-lightbox" src="images/purchase.jpg">&nbsp; &nbsp; &nbsp;
    </div>
    </div>
</div>
<div class="art-content-layout">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-3" style="width: 32%" >
        <p style="font-style:italic">
           Enter a specific date and time 
            <br />to see the available matches starting 
            <br />from the time provided.
            <br />
            <br />
            <br />
        
            <asp:TextBox ID="Date" runat="server" CssClass="art-article" Height="12px" Width="170px"></asp:TextBox>
            <br />
        <br />
            <asp:Button ID="Mat" runat="server" CssClass="art-button" Text="View Matches" OnClick="Mat_Click" Height="30px" Width="130px"/>
            </p>
       

        
    </div><div class="art-layout-cell layout-item-4" style="width: 35%" >
        <p >

            <asp:Label ID="attend" runat="server" Height="257px" Width="294px"></asp:Label>

            </p>
    </div><div class="art-layout-cell layout-item-3" style="width: 33%; top: 0px; left: 0px;" >
        
            <asp:TextBox ID="Host" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; Host<br />
            <br />
            <asp:TextBox ID="Guest" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; Guest<br />
            <br />
            <asp:TextBox ID="StartTime" runat="server" CssClass="art-article" Height="22px" Width="104px" TextMode="DateTimeLocal"/>
            &nbsp; Start Time<br />
            <br />
            <asp:Button ID="Purchase" runat="server" CssClass="art-button" Text="Confirm Purchase" OnClick="ticketPurchase"/>
    </div>
    </div>
</div>
<div class="art-content-layout">

    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-4" style="width: 68%" >
        <h1>Matches</h1>
        <p><span style="font-size: 15px; font-weight: bold;font-family: 'Century Gothic';">

            <br />
            
            <asp:Label ID="Label1" runat="server" Width="600px" Height="500px"></asp:Label></span><br>
            

           </span> <span style="color:rgb(108, 172, 224);">
           
            
            
        </p>
    </div><div class="art-layout-cell layout-item-3" style="width: 32%" >
        <h1>Policy</h1>
        <p style="font-style:italic"><span style="color:rgb(108, 172, 224);"></span><br>

            <strong>
            Note: Tickets are non-refundable <br />
                </strong>
            so please check the details 
            <br />
            of the match you want to attend
            <br />
            and make sure 100% 
            <br />that you will be able to attend the match.
            <br />
            Enjoy your time.
            &nbsp;

         </p>
        <p>&nbsp;</p>
        
    </div>
    </div>

</div>
</div>
                                
                </article>

                        </div>
                    </div>
                </div>
            </div>
    </div>
<footer class="art-footer">
  <div class="art-footer-inner">
<div class="art-content-layout-wrapper layout-item-0">
<div class="art-content-layout layout-item-1">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-2" style="width: 50%">
        <p>Copyright © 2022-2023. All Rights Reserved.</p>
    </div><div class="art-layout-cell layout-item-2" style="width: 50%">
        <p style="text-align: right;"><a href="#">Privacy Policy</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">Terms Of Use</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">About</a></p>
    </div>
    </div>
</div>
</div>

    <p class="art-page-footer">
        <span id="art-footnote-links">Web Template</a> created by segeeny.</span>
    </p>
  </div>
</footer>

</div>
    </form>
</body>
</html>
