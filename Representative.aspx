<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Representative.aspx.cs" Inherits="Sports.Representative" %>

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
    <div class="art-layout-cell layout-item-0" style="width: 33%; top: 0px; left: 0px; height: 262px;" >
        <h4>Club Information</h4>
         <img width="360" height="197" alt="" class="art-lightbox" src="images/sportsclub.jpg">
    </div><div class="art-layout-cell layout-item-1" style="width: 34%" >
        <h4>Available Stadiums</h4>
         <img width="360" height="196" alt="" class="art-lightbox" src="images/match.jpg">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </div>
        <div class="art-layout-cell layout-item-2" style="width: 33%" >
        <h4>Hosting Request</h4>
         <img width="350" height="198" alt="" class="art-lightbox" src="images/stad.png">&nbsp; &nbsp; &nbsp;
    </div>
    </div>
</div>
<div class="art-content-layout">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-3" style="width: 33%; top: -13px; left: 0px; height: 255px;" >
        <p>
           <asp:Label ID="ClubInfo" runat="server" Height="200px" Width="283px" Font-Size="Larger" ></asp:Label>
        </p>
    
            <!--<asp:TextBox ID="Date" runat="server" CssClass="art-article" Height="12px" Width="170px"></asp:TextBox>
            <br />
        <br />
            <asp:Button ID="Mat" runat="server" CssClass="art-button" Text="View Matches"/> !-->
       

        
    </div><div class="art-layout-cell layout-item-4" style="width: 34%; top: 0px; left: -42px; height: 261px;" >
        <p>
            Choose the date and time you wish to
            <br />reserve a stadium for hosting on
            <br />
            <br />
            <!--label for rejected requests!-->
             <asp:TextBox ID="DT" runat="server" TextMode="DateTimeLocal"></asp:TextBox> 
            <br />
            <br />
            <asp:Button ID="ConfirmDate" runat="server" Text="Confirm" OnClick="stadiums" Height="35px" Width="100px" 
                 CssClass="art-button"/>
            
        </p>
    </div><div class="art-layout-cell layout-item-3" style="width: 33%; top: -10px; left: 0px; height: 190px;" >
        
            <asp:TextBox ID="Host" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; Host<br />
            <br />
            <asp:TextBox ID="Stadium" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; Stadium<br />
            <br />
            <asp:TextBox ID="StartTime" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; Start Time<br />
            <br />
            <asp:Button ID="send" runat="server" CssClass="art-button" Text="Send" OnClick="sendRequest" Height="35px" />
            <br />
            <br />
            <br />
       
    </div>
    </div>
</div>
<div class="art-content-layout">

    <div class="art-content-layout-row">
        
    <div class="art-layout-cell layout-item-4" style="width: 68%; top: 0px; left: 0px; height: 285px;" >
        <h1>Upcoming Matches&nbsp; </h1>
        <br />
        <span style="color:rgb(108, 172, 224);">

            <!--Text box to enter a date for hosting!-->
           
            <asp:Label ID="any" runat="server" Text="Host   Guest    Start     End     Stadium" Font-Size="Larger" Font-Bold="true" Font-Italic="true"></asp:Label>
            <br />
            <asp:Label ID="upcomingMatches" runat="server" Height="257px" Width="294px"></asp:Label>

           
            
            <br />
        </span>
            
       
    </div><div class="art-layout-cell layout-item-3" style="width: 32%; top: 0px; left: 0px; height: 302px;" >
        <h1>Stadiums</h1>
        <p><span style="color:rgb(108, 172, 224);">

            <!--label for available stadiums!-->
            <br />
            <asp:Label ID="any2" runat="server" Text="Name    Location   Capacity" Font-Size="Larger" Font-Bold="true" Font-Italic="true"></asp:Label>
            <br />
            <asp:Label ID="available" runat="server"></asp:Label>
           </span><br>
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
