   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	        Presentation.AnalyzeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  AnalyzeWindow��5	   	   $	��450��6   $	��800��6,   .��5
      �� $
��Auto=�6   .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ HeaderPanel��5      $��0��6.    �� Orientation$ 
Horizontal=�6;   $��Stretch=�6T   ���#2d2d2d.+�5      �� -   5        $��
Export TXT��5      $	��100��6.   $��5q�6:   ���#2d2d2d���#5562f3$
��Bold"�6o   $��0q�6�    � Cursor$
 Hand��6�   6�   �� 5      -   5        $��
Export CSV��5      $	��100��6.   $��5q�6:   ���#2d2d2d���#5562f3$
��Bold"�6o   $��0q�6�   $
 Hand��6�   6�   5      �� 5      $��1��6   $��10q�6&   .+�5      �� -   5        $��GamesCountText��5      $��16(�62   $
��Bold"�6@   $��5q�6R   $��Center=�6]   �� 5      -   5        $��PlayersCountText��5      $��16(�64   $
��Bold"�6B   $��5q�6T   $��Center=�6_   �� 5      -   5        $��AveragePriceText��5      $��16(�64   $
��Bold"�6B   $��5q�6T   $��Center=�6_   �� 5      -   5        $��NumberOfSoldGamesText��5      $��16(�69   $
��Bold"�6G   $��5q�6Y   $��Center=�6d   �� 5      -   5        $��TopFiveRatingsText��5      $��16(�66   $
��Bold"�6D   $��5q�6V   $��Center=�6a   �� 5!      $��Genre Distribution��6   $
��Bold"�66   $��16(�6H   $��0,0,0,10q�6V   $��0��6h   $��Center=�6u   #  LiveCharts.Wpf.CartesianChart  5"      -	   5        $��GenreDistributionChart��5"   %   $	��300��6C   $��20q�6P   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�6\   �� 5$      $��Purchases Over Time��6   $
��Bold"�67   $��16(�6I   $��	0,20,0,10q�6W   $��2��6j   $��Center=�6w     5%      -
   5        $��PurchasesOverTimeChart��5%   %   $	��300��6C   $��20q�6P   �� 5'      $��Platform Distribution��6   $
��Bold"�69   $��16(�6K   $��	0,20,0,10q�6Y   $��4��6l   $��Center=�6y     LiveCharts.Wpf.PieChart  5(      -   5        $��PlatformDistributionChart��5(      $	��400��6@   $��20q�6M   5*      5+      5,      5-      