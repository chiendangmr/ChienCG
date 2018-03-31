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
		
	public class DavisCup_TySoNho extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var team1short:TextField = new TextField();
		public var team2short:TextField = new TextField();
		public var setpoint1:TextField = new TextField();
		public var setpoint2:TextField = new TextField();
		public var tyso1:TextField = new TextField();
		public var tyso2:TextField = new TextField();
		public var livepoint1:TextField = new TextField();
		public var livepoint2:TextField = new TextField();		
						
		public function DavisCup_TySoNho() {
			// constructor code
			super();							
			this.txtGroup.addChild(team1short);	
			this.txtGroup.addChild(team2short);
			this.txtGroup.addChild(setpoint1);
			this.txtGroup.addChild(setpoint2);	
			this.txtGroup.addChild(tyso1);
			this.txtGroup.addChild(tyso2);
			this.txtGroup.addChild(livepoint1);	
			this.txtGroup.addChild(livepoint2);
					
			this.txtGroup.addChild(icon1);
			this.txtGroup.addChild(icon2);
			
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
			xmlStr +=Add(xmlStr, "team1short", team1short);
			xmlStr +=Add(xmlStr, "team2short", team2short);
			xmlStr +=Add(xmlStr, "setpoint1", setpoint1);
			xmlStr +=Add(xmlStr, "setpoint2", setpoint2);
			xmlStr +=Add(xmlStr, "tyso1", tyso1);
			xmlStr +=Add(xmlStr, "tyso2", tyso2);	
			xmlStr +=Add(xmlStr, "livepoint1", livepoint1);
			xmlStr +=Add(xmlStr, "livepoint2", livepoint2);				
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
					case "team1short".toLowerCase():
						this.team1short.text = data.toUpperCase();
						break;
					case "team2short".toLowerCase():
						this.team2short.text = data.toUpperCase();
						break;
					case "setpoint1".toLowerCase():
						this.setpoint1.text = data.toUpperCase();
						break;
					case "setpoint2".toLowerCase():
						this.setpoint2.text = data.toUpperCase();
						break;
					case "tyso1".toLowerCase():
						this.tyso1.text = data.toUpperCase();
						break;
					case "tyso2".toLowerCase():
						this.tyso2.text = data.toUpperCase();
						break;	
					case "livepoint1".toLowerCase():
						this.livepoint1.text = data.toUpperCase();
						break;
					case "livepoint2".toLowerCase():
						this.livepoint2.text = data.toUpperCase();
						break;								
					case "icon1".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
						break;
					case "icon2".toLowerCase():						
						var file1:Loader = new Loader();
						file1.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted2);
						file1.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError2);
						file1.load(new URLRequest(data));
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
			bmp.width=45;
			bmp.height=45;
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
			bmp.width=45;
			bmp.height=45;
			this.icon2.addChild(bmp);
		}
	}
	
}
