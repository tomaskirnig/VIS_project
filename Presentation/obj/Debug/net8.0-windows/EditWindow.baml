   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PresentationPresentation  5   	       Presentation.EditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Presentation     5   	     � Title$  Edit Player��5   
   $	��400��6   $	��400��6+   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��First Name:��6   $��0��6'   $��Center=�64   �� 5   
   -   5         ��Name$ FirstNameTextBox��5      $��0��6,   $��	100,0,0,0q�69   �� 5   
   $��
Last Name:��6   $��1��6&   $��Center=�63   �� 5   
   -   5        $ LastNameTextBox��5      $��1��6+   $��	100,0,0,0q�68   �� 5   
   $��Email:��6   $��2��6"   $��Center=�6/   �� 5   
   -   5        $ EmailTextBox��5      $��2��6(   $��	100,0,0,0q�65   �� 5   
   $��	Username:��6   $��3��6%   $��Center=�62   �� 5    
   -   5        $ UsernameTextBox��5       $��3��6+   $��	100,0,0,0q�68    �� 
IsReadOnly$
 True��6K   �� 5"   
   $��	Password:��6   $��4��6%   $��Center=�62   �� 5#   
   -   5        $ PasswordBox��5#      $��4��6'   $��	100,0,0,0q�64   �� 5%   
   $��Role:��6   $��5��6!   $��Center=�6.   �� 5&   
   -   5         ��Name$ RoleComboBox��5&      $��5��6)   $��	100,0,0,0q�66   .@�5'      �� $��Player��6   
 � Tag$ 0��6,   �� 5(      $��Analyst��6   $ 1��6-   �� 5)      $��Admin��6   $ 2��6+   5*      �� 5,   
   $��Date of Birth��6   $��6��6)   $��Center=�66   (  "System.Windows.Controls.DatePicker  5-   
   -   5          Name$ DateOfBirthPicker��5-      $��6��60   $��	100,0,0,0q�6=   �� 5/   
   $��Gender��6   $��7��6"   $��Center=�6/   �� 50   
   -   5        $ GenderComboBox��50      $��7��6+   $��	100,0,0,0q�68   .@�51      �� $
��Male��6   $ 0��6*   �� 52      $��Female��6   $ 1��6,   �� 53      $��Other��6   $ 2��6+   54      �� 56   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�57      �� -	   5        $��Confirm��57      $��20��6'   $	��100��63   $��5q�6?   6J   �� 58      -
   5        $��Close��58      $��20��6%   $	��100��61   $��5q�6=   6H   59      5:      5;      