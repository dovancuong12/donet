   M S B A M L   `   `   `  ����?  ;Cuoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CuoiCuoi  5   	       Cuoi.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Cuoi     5   	   -   5          � Title$  
MainWindow��5   	   $	��800��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6   $��2��5      $��Center=�6$   $��Center=�6A   $��QUẢN LÝ SÁCH��5      $��30(�6'   �� 5   
   $��1��6   $��0��6   $��
Mã sách:��5        	  label#��[  6#   �� 5!   
   -   5         ��Name$ 	maSachtxt��5"      $��1��5!      $��1��6     textBox#��[ 6/   5"      �� 5$   
   $��2��6   $��0��6   $��Tên sách:��5%      #��[  6$   �� 5&   
   -   5        $ 
tenSachtxt��5'      $��2��5&      $��1��6   #��[ 6/   5'      �� 5)   
   $��3��6   $��0��6   $��Số lượng:��5*      #��[  6$   �� 5+   
   -   5        $ 
soLuongtxt��5,      $��3��5+      $��1��6   #��[ 6/   5,      �� 5.   
   $��4��6   $��0��6   $��Mã nhà xuất bản:��5/      #��[  6+   �� 50   
   -   5        $ maNXBtxt��51      $��4��50      $��1��6   #��[ 6/   51      &   System.Windows.Controls.DataGrid  53   
   -   5          Name$ dataGrid��53   D   $��5��6   $��0��6    $��2��60      AutoGenerateColumns$ False��54        dataGrid   ColumnHeaderStyle# [ 6/   $��Center=�55      $��10q�60      Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Mã sách��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *MaSp+  58      $ 
Tên sách��6%   	 67   �� *TenSp+  59      $ Số lượng��6%   	 67   �� *	SoLuong+  5:      $ Tên nhà xuất bản��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5;   %   	 5:   ?   �� *	TenLoai+5;   %   5=      �� 5?   
   $��6��6   $��0��6"   $��2��62   $��Center=�5@      $��Center=�62    �� Orientation$ 
Horizontal=�5A      .+�5B      �� -   5         
 button#��[ 5B        buttonTemplate#��[ 65   $��Thêm��5C      6$   �� 5E      -   5        #��[ 5E      #��[ 65   $
��Xoá��5F      6#   �� 5H      -	   5        #��[ 5H      #��[ 65   $��Thống Kê��5I      6(   5J      5L      5M      