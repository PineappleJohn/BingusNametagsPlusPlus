using BingusNametagsPlusPlus.Interfaces;
using System.Collections.Generic;
using BingusNametagsPlusPlus.Classes;

namespace NametagTemplate
{
    public class MyNametag : IBaseNametag
    {
        public string Name => "Your Plugin Name";
        public string Description => "Write a short description of your plugin here. It is shown to the user on the Plugins tab.";
        public string Author => "Me"; // this is you
        public float Offset => 0.5f; // This is the offset from the user's selected nametag offset. The default nametag's offset is 0f.
        public List<string> Unsupported => []; // Names of any mods that your nametag does not work correctly with, it will disable them when your nametag is enabled
        // The default nametag is named "Default" if you are overriding it
        public bool Enabled { get; set; } = true; // Whether your nametag is enabled. This doesn't matter, it just needs an initial value and will be changed in startup

        // Called every frame to update a nametag.
        public void UpdateNametag(PlayerNametag nametag)
        {
            // Styles are automatically applied when the tag text is set.
            // If you have styling tricks, do them before setting the nametag text with nametag.Text.
            // You can see a full list of tags here: https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/RichText.html

            // Add a styling tag with TextMeshPro, eg. "b" = "bold"
            nametag.AddStyle("b");
            nametag.AddStyle("color", "#2b2b2b"); // for tags like <color=*>, use this syntax instead

            // remove a style if you don't need it anymore
            nametag.RemoveStyle("color");
            nametag.RemoveStyle("b");

            // Set the nametag text like this.
            nametag.Text = nametag.Owner.OwningNetPlayer.NickName;

            /*
            Nametag offset, size, and visibility is automatically determined by BingusNametags++.
            You can turn certain nametags (including the built-in nametag) on/off with the Plugins tab in settings.
            */
        }
    }
}
