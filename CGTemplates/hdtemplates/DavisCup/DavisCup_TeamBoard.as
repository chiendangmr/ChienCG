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
		
	public class DavisCup_TeamBoard extends CasparTemplate{
		
		public var viewGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var giaidau:TextField = new TextField();
		public var vongdau:TextField = new TextField();
		public var character1:TextField = new TextField();
		public var team1:TextField = new TextField();
		public var team2:TextField = new TextField();
		public var character2:TextField = new TextField();
		public var diadiem:TextField = new TextField();
		public var chitietDiaDiem:TextField = new TextField();
		public var team1Player1:TextField = new TextField();
		public var team1Player2:TextField = new TextField();
		public var team1Player3:TextField = new TextField();
		public var team1Player4:TextField = new TextField();
		public var team2Player1:TextField = new TextField();
		public var team2Player2:TextField = new TextField();
		public var team2Player3:TextField = new TextField();
		public var team2Player4:TextField = new TextField();
		public var team1Rank1:TextField = new TextField();
		public var team1Rank2:TextField = new TextField();	
		public var team1Rank3:TextField = new TextField();
		public var team1Rank4:TextField = new TextField();
		public var team2Rank4:TextField = new TextField();
		public var team2Rank3:TextField = new TextField();	
		public var team2Rank2:TextField = new TextField();
		public var team2Rank1:TextField = new TextField();	
		public var captain1:TextField = new TextField();
		public var captain2:TextField = new TextField();	
						
		public function DavisCup_TeamBoard() {
			// constructor code
			super();
			
			this.viewGroup.addChild(giaidau);
			this.viewGroup.addChild(vongdau);
			this.viewGroup.addChild(character1);
			this.viewGroup.addChild(team1);
			this.viewGroup.addChild(team2);
			this.viewGroup.addChild(character2);
			this.viewGroup.addChild(diadiem);
			this.viewGroup.addChild(chitietDiaDiem);
			this.viewGroup.addChild(team1Player1);
			this.viewGroup.addChild(team1Player2);
			this.viewGroup.addChild(team1Player3);
			this.viewGroup.addChild(team1Player4);
			this.viewGroup.addChild(team2Player1);
			this.viewGroup.addChild(team2Player2);
			this.viewGroup.addChild(team2Player3);
			this.viewGroup.addChild(team2Player4);
			this.viewGroup.addChild(team1Rank1);
			this.viewGroup.addChild(team1Rank2);
			this.viewGroup.addChild(team1Rank3);
			this.viewGroup.addChild(team1Rank4);
			this.viewGroup.addChild(team2Rank4);
			this.viewGroup.addChild(team2Rank3);
			this.viewGroup.addChild(team2Rank2);
			this.viewGroup.addChild(team2Rank1);
			this.viewGroup.addChild(captain1);
			this.viewGroup.addChild(captain2);
			this.viewGroup.addChild(icon1);
			this.viewGroup.addChild(icon2);
			this.addChild(viewGroup);
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
			xmlStr +=Add(xmlStr, "giaidau", giaidau);
			xmlStr +=Add(xmlStr, "vongdau", vongdau);
			xmlStr +=Add(xmlStr, "character1", character1);
			xmlStr +=Add(xmlStr, "team1", team1);
			xmlStr +=Add(xmlStr, "team2", team2);
			xmlStr +=Add(xmlStr, "character2", character2);	
			xmlStr +=Add(xmlStr, "team1Player1", team1Player1);
			xmlStr +=Add(xmlStr, "team1Player2", team1Player2);
			xmlStr +=Add(xmlStr, "team1Player3", team1Player3);
			xmlStr +=Add(xmlStr, "team1Player4", team1Player4);
			xmlStr +=Add(xmlStr, "team2Player1", team2Player1);
			xmlStr +=Add(xmlStr, "team2Player2", team2Player2);	
			xmlStr +=Add(xmlStr, "team2Player3", team2Player3);
			xmlStr +=Add(xmlStr, "team2Player4", team2Player4);
			xmlStr +=Add(xmlStr, "team1Rank1", team1Rank1);
			xmlStr +=Add(xmlStr, "team1Rank2", team1Rank2);	
			xmlStr +=Add(xmlStr, "team1Rank3", team1Rank3);
			xmlStr +=Add(xmlStr, "team1Rank4", team1Rank4);
			xmlStr +=Add(xmlStr, "team2Rank4", team2Rank4);
			xmlStr +=Add(xmlStr, "team2Rank3", team2Rank3);
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
					case "giaidau".toLowerCase():
						this.giaidau.text = data.toUpperCase();
						break;
					case "vongdau".toLowerCase():
						this.vongdau.text = data.toUpperCase();
						break;
					case "character1".toLowerCase():
						this.character1.text = data.toUpperCase();
						break;
					case "team1".toLowerCase():
						this.team1.text = data.toUpperCase();
						break;
					case "team2".toLowerCase():
						this.team2.text = data.toUpperCase();
						break;
					case "character2".toLowerCase():
						this.character2.text = data.toUpperCase();
						break;
					case "diadiem".toLowerCase():
						this.diadiem.text = data;
						break;
					case "chitietDiaDiem".toLowerCase():
						this.chitietDiaDiem.text = data;
						break;
					case "team1Player1".toLowerCase():
						this.team1Player1.text = data.toUpperCase();
						break;
					case "team1Player2".toLowerCase():
						this.team1Player2.text = data.toUpperCase();
						break;
					case "team1Player3".toLowerCase():
						this.team1Player3.text = data.toUpperCase();
						break;
					case "team1Player4".toLowerCase():
						this.team1Player4.text = data.toUpperCase();
						break;					
					case "team2Player1".toLowerCase():
						this.team2Player1.text = data.toUpperCase();
						break;
					case "team2Player2".toLowerCase():
						this.team2Player2.text = data.toUpperCase();
						break;
					case "team2Player3".toLowerCase():
						this.team2Player3.text = data.toUpperCase();
						break;
					case "team2Player4".toLowerCase():
						this.team2Player4.text = data.toUpperCase();
						break;
					case "team1Rank1".toLowerCase():
						this.team1Rank1.text = data.toUpperCase();
						break;
					case "team1Rank2".toLowerCase():
						this.team1Rank2.text = data.toUpperCase();
						break;	
					case "team1Rank3".toLowerCase():
						this.team1Rank3.text = data.toUpperCase();
						break;
					case "team1Rank4".toLowerCase():
						this.team1Rank4.text = data.toUpperCase();
						break;
					case "team2Rank4".toLowerCase():
						this.team2Rank4.text = data.toUpperCase();
						break;
					case "team2Rank3".toLowerCase():
						this.team2Rank3.text = data.toUpperCase();
						break;	
					case "team2Rank2".toLowerCase():
						this.team2Rank2.text = data.toUpperCase();
						break;
					case "team2Rank1".toLowerCase():
						this.team2Rank1.text = data.toUpperCase();
						break;	
					case "captain1".toLowerCase():
						this.captain1.text = data.toUpperCase();
						break;
					case "captain2".toLowerCase():
						this.captain2.text = data.toUpperCase();
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
			bmp.width=130;
			bmp.height=130;
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
			bmp.width=130;
			bmp.height=130;
			this.icon2.addChild(bmp);
		}
	}
	
}
