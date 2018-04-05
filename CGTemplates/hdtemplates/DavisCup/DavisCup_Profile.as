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
		
	public class DavisCup_Profile extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var logo:MovieClip;
		
		public var PlayerName:TextField = new TextField();
		public var nation:TextField = new TextField();
		public var age:TextField = new TextField();
		public var heightt:TextField = new TextField();
		public var weightt:TextField = new TextField();
		public var worldRanking:TextField = new TextField();
		public var appearances:TextField = new TextField();
		public var singleWin:TextField = new TextField();
		public var singleLose:TextField = new TextField();
		public var debut:TextField = new TextField();
						
		public function DavisCup_Profile() {
			// constructor code
			super();							
			this.txtGroup.addChild(PlayerName);	
			this.txtGroup.addChild(nation);
			this.txtGroup.addChild(age);
			this.txtGroup.addChild(heightt);	
			this.txtGroup.addChild(weightt);
			this.txtGroup.addChild(worldRanking);
			this.txtGroup.addChild(appearances);	
			this.txtGroup.addChild(singleWin);
			this.txtGroup.addChild(singleLose);
			this.txtGroup.addChild(debut);							
			this.txtGroup.addChild(logo);
			
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
			xmlStr +=Add(xmlStr, "PlayerName", PlayerName);
			xmlStr +=Add(xmlStr, "nation", nation);
			xmlStr +=Add(xmlStr, "age", age);
			xmlStr +=Add(xmlStr, "heightt", heightt);
			xmlStr +=Add(xmlStr, "weightt", weightt);
			xmlStr +=Add(xmlStr, "worldRanking", worldRanking);	
			xmlStr +=Add(xmlStr, "appearances", appearances);
			xmlStr +=Add(xmlStr, "singleWin", singleWin);
			xmlStr +=Add(xmlStr, "singleLose", singleLose);
			xmlStr +=Add(xmlStr, "debut", debut);				
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
					case "PlayerName".toLowerCase():
						this.PlayerName.text = data.toUpperCase();
						break;
					case "nation".toLowerCase():
						this.nation.text = data.toUpperCase();
						break;
					case "age".toLowerCase():
						this.age.text = data.toUpperCase();
						break;
					case "heightt".toLowerCase():
						this.heightt.text = data.toUpperCase();
						break;
					case "weightt".toLowerCase():
						this.weightt.text = data.toUpperCase();
						break;
					case "worldRanking".toLowerCase():
						this.worldRanking.text = data.toUpperCase();
						break;	
					case "appearances".toLowerCase():
						this.appearances.text = data.toUpperCase();
						break;
					case "singleWin".toLowerCase():
						this.singleWin.text = data.toUpperCase();
						break;
					case "singleLose".toLowerCase():
						this.singleLose.text = data.toUpperCase();
						break;
					case "debut".toLowerCase():
						this.debut.text = data.toUpperCase();
						break;						
					case "logo".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
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
			while(this.logo.numChildren > 0)
				this.logo.removeChildAt(0);
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=100;
			bmp.height=100;
			this.logo.addChild(bmp);
		}		
	}
	
}
