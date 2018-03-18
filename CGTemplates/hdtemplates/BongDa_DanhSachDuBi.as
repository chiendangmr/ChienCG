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
		
	public class BongDa_DanhSachDuBi extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;	
		public var icon2:MovieClip;
			
		public var title:TextField = new TextField();
		public var doiChu:TextField = new TextField();
		public var doiKhach:TextField = new TextField();
		public var dubiChuNumber1:TextField = new TextField();
		public var dubiChuNumber2:TextField = new TextField();
		public var dubiChuNumber3:TextField = new TextField();
		public var dubiChuNumber4:TextField = new TextField();
		public var dubiChuNumber5:TextField = new TextField();
		public var dubiChuNumber6:TextField = new TextField();
		public var dubiChuNumber7:TextField = new TextField();
		public var dubiChuNumber8:TextField = new TextField();
		public var dubiChuNumber9:TextField = new TextField();
		
		public var dubiChuName1:TextField = new TextField();
		public var dubiChuName2:TextField = new TextField();
		public var dubiChuName3:TextField = new TextField();
		public var dubiChuName4:TextField = new TextField();
		public var dubiChuName5:TextField = new TextField();
		public var dubiChuName6:TextField = new TextField();
		public var dubiChuName7:TextField = new TextField();
		public var dubiChuName8:TextField = new TextField();
		public var dubiChuName9:TextField = new TextField();
		
		public var dubiKhachNumber1:TextField = new TextField();
		public var dubiKhachNumber2:TextField = new TextField();
		public var dubiKhachNumber3:TextField = new TextField();
		public var dubiKhachNumber4:TextField = new TextField();
		public var dubiKhachNumber5:TextField = new TextField();
		public var dubiKhachNumber6:TextField = new TextField();
		public var dubiKhachNumber7:TextField = new TextField();
		public var dubiKhachNumber8:TextField = new TextField();
		public var dubiKhachNumber9:TextField = new TextField();
		
		public var dubiKhachName1:TextField = new TextField();
		public var dubiKhachName2:TextField = new TextField();
		public var dubiKhachName3:TextField = new TextField();
		public var dubiKhachName4:TextField = new TextField();
		public var dubiKhachName5:TextField = new TextField();
		public var dubiKhachName6:TextField = new TextField();
		public var dubiKhachName7:TextField = new TextField();
		public var dubiKhachName8:TextField = new TextField();
		public var dubiKhachName9:TextField = new TextField();
		
		
		public function BongDa_DanhSachDuBi() {
			// constructor code
			super();							
			this.txtGroup.addChild(doiChu);	
			this.txtGroup.addChild(doiKhach);
			this.txtGroup.addChild(dubiChuNumber1);
			this.txtGroup.addChild(dubiChuNumber2);	
			this.txtGroup.addChild(dubiChuNumber3);
			this.txtGroup.addChild(dubiChuNumber4);
			this.txtGroup.addChild(dubiChuNumber5);	
			this.txtGroup.addChild(dubiChuNumber6);
			this.txtGroup.addChild(dubiChuNumber7);
			this.txtGroup.addChild(dubiChuNumber8);	
			this.txtGroup.addChild(dubiChuNumber9);
			
			this.txtGroup.addChild(dubiChuName1);
			this.txtGroup.addChild(dubiChuName2);
			this.txtGroup.addChild(dubiChuName3);	
			this.txtGroup.addChild(dubiChuName4);
			this.txtGroup.addChild(dubiChuName5);
			this.txtGroup.addChild(dubiChuName6);	
			this.txtGroup.addChild(dubiChuName7);
			this.txtGroup.addChild(dubiChuName8);
			this.txtGroup.addChild(dubiChuName9);	
			
			this.txtGroup.addChild(dubiKhachNumber1);
			this.txtGroup.addChild(dubiKhachNumber2);
			this.txtGroup.addChild(dubiKhachNumber3);	
			this.txtGroup.addChild(dubiKhachNumber4);
			this.txtGroup.addChild(dubiKhachNumber5);
			this.txtGroup.addChild(dubiKhachNumber6);	
			this.txtGroup.addChild(dubiKhachNumber7);
			this.txtGroup.addChild(dubiKhachNumber8);
			this.txtGroup.addChild(dubiKhachNumber9);	
			
			this.txtGroup.addChild(dubiKhachName1);
			this.txtGroup.addChild(dubiKhachName2);	
			this.txtGroup.addChild(dubiKhachName3);
			this.txtGroup.addChild(dubiKhachName4);
			this.txtGroup.addChild(dubiKhachName5);	
			this.txtGroup.addChild(dubiKhachName6);
			this.txtGroup.addChild(dubiKhachName7);
			this.txtGroup.addChild(dubiKhachName8);	
			this.txtGroup.addChild(dubiKhachName9);
			
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
			xmlStr +=Add(xmlStr, "dubiChuNumber1", dubiChuNumber1);
			xmlStr +=Add(xmlStr, "dubiChuNumber2", dubiChuNumber2);
			xmlStr +=Add(xmlStr, "dubiChuNumber3", dubiChuNumber3);
			xmlStr +=Add(xmlStr, "dubiChuNumber4", dubiChuNumber4);
			xmlStr +=Add(xmlStr, "dubiChuNumber5", dubiChuNumber5);
			xmlStr +=Add(xmlStr, "dubiChuNumber6", dubiChuNumber6);
			xmlStr +=Add(xmlStr, "dubiChuNumber7", dubiChuNumber7);
			xmlStr +=Add(xmlStr, "dubiChuNumber8", dubiChuNumber8);
			xmlStr +=Add(xmlStr, "dubiChuNumber9", dubiChuNumber9);
			
			xmlStr +=Add(xmlStr, "dubiChuName1", dubiChuName1);
			xmlStr +=Add(xmlStr, "dubiChuName2", dubiChuName2);
			xmlStr +=Add(xmlStr, "dubiChuName3", dubiChuName3);
			xmlStr +=Add(xmlStr, "dubiChuName4", dubiChuName4);
			xmlStr +=Add(xmlStr, "dubiChuName5", dubiChuName5);
			xmlStr +=Add(xmlStr, "dubiChuName6", dubiChuName6);
			xmlStr +=Add(xmlStr, "dubiChuName7", dubiChuName7);
			xmlStr +=Add(xmlStr, "dubiChuName8", dubiChuName8);
			xmlStr +=Add(xmlStr, "dubiChuName9", dubiChuName9);
			
			xmlStr +=Add(xmlStr, "dubiKhachNumber1", dubiKhachNumber1);
			xmlStr +=Add(xmlStr, "dubiKhachNumber2", dubiKhachNumber2);
			xmlStr +=Add(xmlStr, "dubiKhachNumber3", dubiKhachNumber3);
			xmlStr +=Add(xmlStr, "dubiKhachNumber4", dubiKhachNumber4);
			xmlStr +=Add(xmlStr, "dubiKhachNumber5", dubiKhachNumber5);
			xmlStr +=Add(xmlStr, "dubiKhachNumber6", dubiKhachNumber6);
			xmlStr +=Add(xmlStr, "dubiKhachNumber7", dubiKhachNumber7);
			xmlStr +=Add(xmlStr, "dubiKhachNumber8", dubiKhachNumber8);
			xmlStr +=Add(xmlStr, "dubiKhachNumber9", dubiKhachNumber9);
			xmlStr +=Add(xmlStr, "dubiKhachName1", dubiKhachName1);
			xmlStr +=Add(xmlStr, "dubiKhachName2", dubiKhachName2);
			xmlStr +=Add(xmlStr, "dubiKhachName3", dubiKhachName3);
			xmlStr +=Add(xmlStr, "dubiKhachName4", dubiKhachName4);
			xmlStr +=Add(xmlStr, "dubiKhachName5", dubiKhachName5);
			xmlStr +=Add(xmlStr, "dubiKhachName6", dubiKhachName6);
			xmlStr +=Add(xmlStr, "dubiKhachName7", dubiKhachName7);
			xmlStr +=Add(xmlStr, "dubiKhachName8", dubiKhachName8);
			xmlStr +=Add(xmlStr, "dubiKhachName9", dubiKhachName9);
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
					case "dubiChuNumber1".toLowerCase():
						this.dubiChuNumber1.text = data.toUpperCase();
						break;
					case "dubiChuNumber2".toLowerCase():
						this.dubiChuNumber2.text = data.toUpperCase();
						break;
					case "dubiChuNumber3".toLowerCase():
						this.dubiChuNumber3.text = data.toUpperCase();
						break;
					case "dubiChuNumber4".toLowerCase():
						this.dubiChuNumber4.text = data.toUpperCase();
						break;
					case "dubiChuNumber5".toLowerCase():
						this.dubiChuNumber5.text = data.toUpperCase();
						break;
					case "dubiChuNumber6".toLowerCase():
						this.dubiChuNumber6.text = data.toUpperCase();
						break;
					case "dubiChuNumber7".toLowerCase():
						this.dubiChuNumber7.text = data.toUpperCase();
						break;
					case "dubiChuNumber8".toLowerCase():
						this.dubiChuNumber8.text = data.toUpperCase();
						break;
					case "dubiChuNumber9".toLowerCase():
						this.dubiChuNumber9.text = data.toUpperCase();
						break;
					
					case "dubiChuName1".toLowerCase():
						this.dubiChuName1.text = data.toUpperCase();
						break;
					case "dubiChuName2".toLowerCase():
						this.dubiChuName2.text=data.toUpperCase();
						break;
					case "dubiChuName3".toLowerCase():
						this.dubiChuName3.text = data.toUpperCase();
						break;
					case "dubiChuName4".toLowerCase():
						this.dubiChuName4.text = data.toUpperCase();
						break;
					case "dubiChuName5".toLowerCase():
						this.dubiChuName5.text = data.toUpperCase();
						break;
					case "dubiChuName6".toLowerCase():
						this.dubiChuName6.text = data.toUpperCase();
						break;
					case "dubiChuName7".toLowerCase():
						this.dubiChuName7.text = data.toUpperCase();
						break;
					case "dubiChuName8".toLowerCase():
						this.dubiChuName8.text = data.toUpperCase();
						break;
					case "dubiChuName9".toLowerCase():
						this.dubiChuName9.text = data.toUpperCase();
						break;
					
					case "dubiKhachNumber1".toLowerCase():
						this.dubiKhachNumber1.text = data.toUpperCase();
						break;
					case "dubiKhachNumber2".toLowerCase():
						this.dubiKhachNumber2.text = data.toUpperCase();
						break;
					case "dubiKhachNumber3".toLowerCase():
						this.dubiKhachNumber3.text = data.toUpperCase();
						break;
					case "dubiKhachNumber4".toLowerCase():
						this.dubiKhachNumber4.text = data.toUpperCase();
						break;
					case "dubiKhachNumber5".toLowerCase():
						this.dubiKhachNumber5.text = data.toUpperCase();
						break;
					case "dubiKhachNumber6".toLowerCase():
						this.dubiKhachNumber6.text = data.toUpperCase();
						break;
					case "dubiKhachNumber7".toLowerCase():
						this.dubiKhachNumber7.text = data.toUpperCase();
						break;
					case "dubiKhachNumber8".toLowerCase():
						this.dubiKhachNumber8.text = data.toUpperCase();
						break;
					case "dubiKhachNumber9".toLowerCase():
						this.dubiKhachNumber9.text = data.toUpperCase();
						break;
					
					case "dubiKhachName1".toLowerCase():
						this.dubiKhachName1.text = data.toUpperCase();
						break;
					case "dubiKhachName2".toLowerCase():
						this.dubiKhachName2.text = data.toUpperCase();
						break;
					case "dubiKhachName3".toLowerCase():
						this.dubiKhachName3.text = data.toUpperCase();
						break;
					case "dubiKhachName4".toLowerCase():
						this.dubiKhachName4
					case "dubiKhachName5".toLowerCase():
						this.dubiKhachName5.text = data.toUpperCase();
						break;
					case "dubiKhachName6".toLowerCase():
						this.dubiKhachName6.text = data.toUpperCase();
						break;
					case "dubiKhachName7".toLowerCase():
						this.dubiKhachName7.text = data.toUpperCase();
						break;
					case "dubiKhachName8".toLowerCase():
						this.dubiKhachName8.text = data.toUpperCase();
						break;
					case "dubiKhachName9".toLowerCase():
						this.dubiKhachName9.text = data.toUpperCase();
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
