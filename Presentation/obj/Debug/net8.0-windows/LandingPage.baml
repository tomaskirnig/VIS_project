   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.LandingPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	     � Title$  LandingPage��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ HeaderPanel��5      $��0��6*   $��0��67   $��3��6G    �� Orientation$ 
Horizontal=�6[   $��Stretch=�6t   ���#2d2d2d.+�5      �� -   5        $��Katalog��5      $	��100��6'   $��5q�63   ���#2d2d2d���#5562f3$
��Bold"�6h   $��0q�6�    � Cursor$
 Hand��6�   6�   �� 5      -   5        $��Knihovna��5      $	��100��6(   $��5q�64   ���#2d2d2d���#5562f3$
��Bold"�6i   $��0q�6�   $
 Hand��6�   6�   �� 5      -   5        $��Profil��5      $	��100��6&   $��5q�62   ���#2d2d2d���#5562f3$
��Bold"�6g   $��0q�6�   $
 Hand��6�   6�   �� 5      -   5        $��
Nastavení��5      $	��100��6)   $��5q�65   ���#2d2d2d���#5562f3$
��Bold"�6j   $
 Hand��6�   $��0q�6�   6�   5      �� 5   
   -   5         ��Name$ LoginLogoutButton��5      $��Login��6,   $��0��6<   $��2��6I   $��75��6Y   $��5q�6d   $��Right=�6o   $��Center=�6�   ���#2d2d2d���#5562f3$
��Bold"�5   ;   $��0q�6W   $
 Hand��6k   5      �� 5    
   -   5        $��ContentArea��5       $��1��6*   $��3��67   $
��Auto=�6K   .��5!      A� -   5         A�Name$ 	GamesGrid��5!       A� Columns$ 3��6-   5"      5$      5%      