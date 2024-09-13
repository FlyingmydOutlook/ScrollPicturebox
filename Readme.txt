****ScrollPictureBox如何使用？不能直接拖入Form了事，需要激活自适应功能。
自适应外部父控件大小和图片大小：
	要自适应外部父控件大小和图片大小，需要在在外部，也就是放置ScrollPictureBox的窗体(Form)里让ScrollPictureBox的Size=父控件（假设是panel）要用AdjustScrollPictureboxSize（）
	我已经封装了private void AdjustScrollPictureboxSize(Bitmap bitmap)函数,代码放在ScrollPictureBox.cs的开头说明里，
	！！！特别需要注意的：（1）AdjustScrollPictureboxSize函数需要读取一个全局变量Size panel2OriginalSize = new System.Drawing.Size(1153, 533);这个Size需要自己指定。
				      （2）给放置他的父容器设置边框，因为ScrollPictureBox在加载图片前是不可见的。this.panel.BorderStyle=Fixed3D;
	
SetLabelLongPressHandler(Label label, LabelLongPressEventHandler handler)
设置标签的长按事件处理程序。

SetLabelClickHandler(Label label, LabelClickEventHandler handler)
设置标签的点击事件处理程序。

LoadImage(Bitmap bitmap)
加载单张图片。

SetscrollSpeed(int value)
设置滚动速度,默认为2

SetCrosshairColor(Color value)
设置十字线的颜色，默认为红色，可设透明。

SetCrosshairLineWidth(float value)
设置十字线的宽度，默认为1

SetLineColor(Color value)
设置线条颜色，默认为红。

SetTextColor(Color value)
设置文本颜色，默认为黑。

SetTextFont(Font value)
设置文本字体。

SetLineWidth(float value)
设置线条宽度，默认为1。

GetStart()
获取起点坐标。

GetEnd()
获取终点坐标。

LoadBackgroundImage(string path)
加载背景图片。

（不推荐使用）
LoadImages(List<string> imagePaths)
加载多张图片。
