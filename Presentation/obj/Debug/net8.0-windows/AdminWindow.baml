   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	     � Title$  AdminWindow��5   	   $	��550��6   $	��850��6*   .��5	      � $��10q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��PlayersDataGrid��5
         AutoGenerateColumns$ False��6*      CanUserAddRows$ False��6F   $��0,0,0,50q�6]      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Player ID��6%      
IsReadOnly$
 True��6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
PlayerId+6U     5      $ Username��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6T    67   �� *
UserName+6T     5      $ 
First Name��6%   $	 100 6W    69   �� *	FirstName+6W     5      $ 	Last Name��6%   $	 100 6U    68   �� *
LastName+6U     5      $
 Role��6%   $ 50 6L    63   �� *Role+6L     5      $ Email��6%   $	 200 6N    64   �� *Email+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)   $	 200 6:      CellTemplate 5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�6)   $��Center=�6B   .+�5   "   �� -   5        $
��Edit��5   )   $��50��68   $��5q�6C   
 � Cursor$

 Hand��6N   6\   �� 5   "   -   5        $��Delete��5   )   $��50��6:   $��5q�6E   $

 Hand��6P   6^   5      5      5      5      5      5      