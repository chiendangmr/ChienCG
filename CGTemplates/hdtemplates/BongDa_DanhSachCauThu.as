package  {
	
	import flash.display.MovieClip;
	import se.svt.caspar.template.CasparTemplate;
	import flash.text.TextField;
	import flash.text.TextFormat;
	import flash.text.Font;
	import flash.text.TextFieldType;
	import fl.transitions.Tween;
	import fl.transitions.easing.*;
	import flash.display.Shape;
	import flash.geom.Matrix;
	import flash.display.GradientType;
	import fl.transitions.TweenEvent;
	import flash.events.Event;
	import flash.text.TextFormatAlign;
	import flash.filters.*;
	import flash.external.ExternalInterface;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import flash.display.Loader;
	import flash.events.IOErrorEvent;
	import flash.display.DisplayObject;
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class BongDa_DanhSachCauThu extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;	
		public var icon2:MovieClip;
			
		public var title:TextField = new TextField();
		public var doiChu:TextField = new TextField();
		public var doiKhach:TextField = new TextField();
		public var chinhthucChuNumber1:TextField = new TextField();
		public var chinhthucChuNumber2:TextField = new TextField();
		public var chinhthucChuNumber3:TextField = new TextField();
		public var chinhthucChuNumber4:TextField = new TextField();
		public var chinhthucChuNumber5:TextField = new TextField();
		public var chinhthucChuNumber6:TextField = new TextField();
		public var chinhthucChuNumber7:TextField = new TextField();
		public var chinhthucChuNumber8:TextField = new TextField();
		public var chinhthucChuNumber9:TextField = new TextField();
		public var chinhthucChuNumber10:TextField = new TextField();
		public var chinhthucChuNumber11:TextField = new TextField();
		public var chinhthucChuName1:TextField = new TextField();
		public var chinhthucChuName2:TextField = new TextField();
		public var chinhthucChuName3:TextField = new TextField();
		public var chinhthucChuName4:TextField = new TextField();
		public var chinhthucChuName5:TextField = new TextField();
		public var chinhthucChuName6:TextField = new TextField();
		public var chinhthucChuName7:TextField = new TextField();
		public var chinhthucChuName8:TextField = new TextField();
		public var chinhthucChuName9:TextField = new TextField();
		public var chinhthucChuName10:TextField = new TextField();
		public var chinhthucChuName11:TextField = new TextField();
		
		public var chinhthucKhachNumber1:TextField = new TextField();
		public var chinhthucKhachNumber2:TextField = new TextField();
		public var chinhthucKhachNumber3:TextField = new TextField();
		public var chinhthucKhachNumber4:TextField = new TextField();
		public var chinhthucKhachNumber5:TextField = new TextField();
		public var chinhthucKhachNumber6:TextField = new TextField();
		public var chinhthucKhachNumber7:TextField = new TextField();
		public var chinhthucKhachNumber8:TextField = new TextField();
		public var chinhthucKhachNumber9:TextField = new TextField();
		public var chinhthucKhachNumber10:TextField = new TextField();
		public var chinhthucKhachNumber11:TextField = new TextField();
		public var chinhthucKhachName1:TextField = new TextField();
		public var chinhthucKhachName2:TextField = new TextField();
		public var chinhthucKhachName3:TextField = new TextField();
		public var chinhthucKhachName4:TextField = new TextField();
		public var chinhthucKhachName5:TextField = new TextField();
		public var chinhthucKhachName6:TextField = new TextField();
		public var chinhthucKhachName7:TextField = new TextField();
		public var chinhthucKhachName8:TextField = new TextField();
		public var chinhthucKhachName9:TextField = new TextField();
		public var chinhthucKhachName10:TextField = new TextField();
		public var chinhthucKhachName11:TextField = new TextField();
		
		public function BongDa_DanhSachCauThu() {
			// constructor code
			super();							
			this.txtGroup.addChild(doiChu);	
			this.txtGroup.addChild(doiKhach);
			this.txtGroup.addChild(chinhthucChuNumber1);
			this.txtGroup.addChild(chinhthucChuNumber2);	
			this.txtGroup.addChild(chinhthucChuNumber3);
			this.txtGroup.addChild(chinhthucChuNumber4);
			this.txtGroup.addChild(chinhthucChuNumber5);	
			this.txtGroup.addChild(chinhthucChuNumber6);
			this.txtGroup.addChild(chinhthucChuNumber7);
			this.txtGroup.addChild(chinhthucChuNumber8);	
			this.txtGroup.addChild(chinhthucChuNumber9);
			this.txtGroup.addChild(chinhthucChuNumber10);
			this.txtGroup.addChild(chinhthucChuNumber11);	
			this.txtGroup.addChild(chinhthucChuName1);
			this.txtGroup.addChild(chinhthucChuName2);
			this.txtGroup.addChild(chinhthucChuName3);	
			this.txtGroup.addChild(chinhthucChuName4);
			this.txtGroup.addChild(chinhthucChuName5);
			this.txtGroup.addChild(chinhthucChuName6);	
			this.txtGroup.addChild(chinhthucChuName7);
			this.txtGroup.addChild(chinhthucChuName8);
			this.txtGroup.addChild(chinhthucChuName9);	
			this.txtGroup.addChild(chinhthucChuName10);
			this.txtGroup.addChild(chinhthucChuName11);
			this.txtGroup.addChild(chinhthucKhachNumber1);
			this.txtGroup.addChild(chinhthucKhachNumber2);
			this.txtGroup.addChild(chinhthucKhachNumber3);	
			this.txtGroup.addChild(chinhthucKhachNumber4);
			this.txtGroup.addChild(chinhthucKhachNumber5);
			this.txtGroup.addChild(chinhthucKhachNumber6);	
			this.txtGroup.addChild(chinhthucKhachNumber7);
			this.txtGroup.addChild(chinhthucKhachNumber8);
			this.txtGroup.addChild(chinhthucKhachNumber9);	
			this.txtGroup.addChild(chinhthucKhachNumber10);
			this.txtGroup.addChild(chinhthucKhachNumber11);	
			this.txtGroup.addChild(chinhthucKhachName1);
			this.txtGroup.addChild(chinhthucKhachName2);	
			this.txtGroup.addChild(chinhthucKhachName3);
			this.txtGroup.addChild(chinhthucKhachName4);
			this.txtGroup.addChild(chinhthucKhachName5);	
			this.txtGroup.addChild(chinhthucKhachName6);
			this.txtGroup.addChild(chinhthucKhachName7);
			this.txtGroup.addChild(chinhthucKhachName8);	
			this.txtGroup.addChild(chinhthucKhachName9);
			this.txtGroup.addChild(chinhthucKhachName10);	
			this.txtGroup.addChild(chinhthucKhachName11);
			this.txtGroup.addChild(icon1);
			this.txtGroup.addChild(icon2);
			this.txtGroup.addChild(title);
			
			this.addChild(txtGroup);
			ExternalInterface.addCallback("UpdateData", UpdateData);
			ExternalInterface.addCallback("GetProperties", GetProperties);			
		}		
		
		private function Add(xmlStr:String, str:String, txt:TextField){
			xmlStr='<'+ str + ' id="'+ str + '"><data value="' + txt.text + '"/></' + str +'>';
			return xmlStr;
		}
		function GetProperties()
		{
			var xmlStr:String = "<Track_Property>";
			xmlStr +=Add(xmlStr, "doiChu", doiChu);
			xmlStr +=Add(xmlStr, "doiKhach", doiKhach);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber1", chinhthucChuNumber1);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber2", chinhthucChuNumber2);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber3", chinhthucChuNumber3);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber4", chinhthucChuNumber4);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber5", chinhthucChuNumber5);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber6", chinhthucChuNumber6);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber7", chinhthucChuNumber7);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber8", chinhthucChuNumber8);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber9", chinhthucChuNumber9);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber10", chinhthucChuNumber10);
			xmlStr +=Add(xmlStr, "chinhthucChuNumber11", chinhthucChuNumber11);
			xmlStr +=Add(xmlStr, "chinhthucChuName1", chinhthucChuName1);
			xmlStr +=Add(xmlStr, "chinhthucChuName2", chinhthucChuName2);
			xmlStr +=Add(xmlStr, "chinhthucChuName3", chinhthucChuName3);
			xmlStr +=Add(xmlStr, "chinhthucChuName4", chinhthucChuName4);
			xmlStr +=Add(xmlStr, "chinhthucChuName5", chinhthucChuName5);
			xmlStr +=Add(xmlStr, "chinhthucChuName6", chinhthucChuName6);
			xmlStr +=Add(xmlStr, "chinhthucChuName7", chinhthucChuName7);
			xmlStr +=Add(xmlStr, "chinhthucChuName8", chinhthucChuName8);
			xmlStr +=Add(xmlStr, "chinhthucChuName9", chinhthucChuName9);
			xmlStr +=Add(xmlStr, "chinhthucChuName10", chinhthucChuName10);
			xmlStr +=Add(xmlStr, "chinhthucChuName11", chinhthucChuName11);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber1", chinhthucKhachNumber1);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber2", chinhthucKhachNumber2);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber3", chinhthucKhachNumber3);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber4", chinhthucKhachNumber4);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber5", chinhthucKhachNumber5);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber6", chinhthucKhachNumber6);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber7", chinhthucKhachNumber7);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber8", chinhthucKhachNumber8);
			xmlStr +=Add(xmlStr, "chinhthucKhachNumber9", chinhthucKhachNumber9);
			xmlStr +=Add(xmlStr, "chinhthucKhachName1", chinhthucKhachName1);
			xmlStr +=Add(xmlStr, "chinhthucKhachName2", chinhthucKhachName2);
			xmlStr +=Add(xmlStr, "chinhthucKhachName3", chinhthucKhachName3);
			xmlStr +=Add(xmlStr, "chinhthucKhachName4", chinhthucKhachName4);
			xmlStr +=Add(xmlStr, "chinhthucKhachName5", chinhthucKhachName5);
			xmlStr +=Add(xmlStr, "chinhthucKhachName6", chinhthucKhachName6);
			xmlStr +=Add(xmlStr, "chinhthucKhachName7", chinhthucKhachName7);
			xmlStr +=Add(xmlStr, "chinhthucKhachName8", chinhthucKhachName8);
			xmlStr +=Add(xmlStr, "chinhthucKhachName9", chinhthucKhachName9);
			xmlStr += "</Track_Property>";
			
			ExternalInterface.call("Properties", xmlStr);
			return xmlStr;
		}
		function UpdateData(str:String)
		{
			var xml:XML = new XML(str);
			this.SetData(xml);
		}
		
		override public function SetData(xml:XML):void{
			for each (var element:XML in xml.children())
			{
				var property:String = element.@id;
				var data:String = element.data.@value;
				switch(property.toLowerCase())
				{						
					case "doiChu".toLowerCase():
						this.doiChu.text = data.toUpperCase();
						break;
					case "doiKhach".toLowerCase():
						this.doiKhach.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber1".toLowerCase():
						this.chinhthucChuNumber1.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber2".toLowerCase():
						this.chinhthucChuNumber2.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber3".toLowerCase():
						this.chinhthucChuNumber3.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber4".toLowerCase():
						this.chinhthucChuNumber4.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber5".toLowerCase():
						this.chinhthucChuNumber5.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber6".toLowerCase():
						this.chinhthucChuNumber6.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber7".toLowerCase():
						this.chinhthucChuNumber7.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber8".toLowerCase():
						this.chinhthucChuNumber8.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber9".toLowerCase():
						this.chinhthucChuNumber9.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber10".toLowerCase():
						this.chinhthucChuNumber10.text = data.toUpperCase();
						break;
					case "chinhthucChuNumber11".toLowerCase():
						this.chinhthucChuNumber11.text = data.toUpperCase();
						break;
					case "chinhthucChuName1".toLowerCase():
						this.chinhthucChuName1.text = data.toUpperCase();
						break;
					case "chinhthucChuName2".toLowerCase():
						this.chinhthucChuName2.text=data.toUpperCase();
						break;
					case "chinhthucChuName3".toLowerCase():
						this.chinhthucChuName3.text = data.toUpperCase();
						break;
					case "chinhthucChuName4".toLowerCase():
						this.chinhthucChuName4.text = data.toUpperCase();
						break;
					case "chinhthucChuName5".toLowerCase():
						this.chinhthucChuName5.text = data.toUpperCase();
						break;
					case "chinhthucChuName6".toLowerCase():
						this.chinhthucChuName6.text = data.toUpperCase();
						break;
					case "chinhthucChuName7".toLowerCase():
						this.chinhthucChuName7.text = data.toUpperCase();
						break;
					case "chinhthucChuName8".toLowerCase():
						this.chinhthucChuName8.text = data.toUpperCase();
						break;
					case "chinhthucChuName9".toLowerCase():
						this.chinhthucChuName9.text = data.toUpperCase();
						break;
					case "chinhthucChuName10".toLowerCase():
						this.chinhthucChuName10.text = data.toUpperCase();
						break;
					case "chinhthucChuName11".toLowerCase():
						this.chinhthucChuName11.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber1".toLowerCase():
						this.chinhthucKhachNumber1.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber2".toLowerCase():
						this.chinhthucKhachNumber2.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber3".toLowerCase():
						this.chinhthucKhachNumber3.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber4".toLowerCase():
						this.chinhthucKhachNumber4.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber5".toLowerCase():
						this.chinhthucKhachNumber5.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber6".toLowerCase():
						this.chinhthucKhachNumber6.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber7".toLowerCase():
						this.chinhthucKhachNumber7.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber8".toLowerCase():
						this.chinhthucKhachNumber8.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber9".toLowerCase():
						this.chinhthucKhachNumber9.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber10".toLowerCase():
						this.chinhthucKhachNumber10.text = data.toUpperCase();
						break;
					case "chinhthucKhachNumber11".toLowerCase():
						this.chinhthucKhachNumber11.text = data.toUpperCase();
						break;
					case "chinhthucKhachName1".toLowerCase():
						this.chinhthucKhachName1.text = data.toUpperCase();
						break;
					case "chinhthucKhachName2".toLowerCase():
						this.chinhthucKhachName2.text = data.toUpperCase();
						break;
					case "chinhthucKhachName3".toLowerCase():
						this.chinhthucKhachName3.text = data.toUpperCase();
						break;
					case "chinhthucKhachName4".toLowerCase():
						this.chinhthucKhachName4
					case "chinhthucKhachName5".toLowerCase():
						this.chinhthucKhachName5.text = data.toUpperCase();
						break;
					case "chinhthucKhachName6".toLowerCase():
						this.chinhthucKhachName6.text = data.toUpperCase();
						break;
					case "chinhthucKhachName7".toLowerCase():
						this.chinhthucKhachName7.text = data.toUpperCase();
						break;
					case "chinhthucKhachName8".toLowerCase():
						this.chinhthucKhachName8.text = data.toUpperCase();
						break;
					case "chinhthucKhachName9".toLowerCase():
						this.chinhthucKhachName9.text = data.toUpperCase();
						break;
					case "chinhthucKhachName10".toLowerCase():
						this.chinhthucKhachName10.text = data.toUpperCase();
						break;
					case "chinhthucKhachName11".toLowerCase():
						this.chinhthucKhachName11.text = data.toUpperCase();
						break;
					case "icon1".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
						break;
					case "icon2".toLowerCase():						
						var file2:Loader = new Loader();
						file2.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted2);
						file2.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError2);
						file2.load(new URLRequest(data));
						break;
				}
			}
		}
		public override function Play():void{
			gotoAndPlay('start');
		}
		public override function Stop():void{
			gotoAndPlay('stop');
		}
		private function onOpenImageError(e:IOErrorEvent)
		{
			while(this.icon1.numChildren > 0)
				this.icon1.removeChildAt(0);
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=60;
			bmp.height=52;
			this.icon1.addChild(bmp);
		}
		
		private function onOpenImageError2(e:IOErrorEvent)
		{
			while(this.icon2.numChildren > 0)
				this.icon2.removeChildAt(0);
		}
		
		private function onOpenImageCompleted2(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;			
			bmp.width=60;
			bmp.height=52;
			this.icon2.addChild(bmp);
		}
	}
	
}
