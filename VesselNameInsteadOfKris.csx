EnsureDataLoaded();

UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);

string displayName = Data.GeneralInfo.DisplayName.Content;

if (!displayName.StartsWith("DELTARUNE Chapter"))
{
  ScriptError("This script is for DELTARUNE chapters only");
}

var scr_84_get_lang_string = Data.Scripts.ByName("scr_84_get_lang_string")?.Code;

if (scr_84_get_lang_string is not UndertaleCode) {
  ScriptError("scr_84_get_lang_string is missing");
}

string chapter = displayName.Split(" ")[2];

switch (chapter)
{
  case "1":
  importGroup.QueueFindReplace(scr_84_get_lang_string, "return ds_map_find_value(global.lang_map, arg0);", @"var text = ds_map_find_value(global.lang_map, arg0);
  if (variable_global_exists(""othername"") && is_array(global.othername)) {
    text = string_replace(text, ""KRIS"", global.othername[0]);
    text = string_replace(text, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    text = string_replace(text, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    text = string_replace(text, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  return text;"
  );
  break;
  default:
  ScriptError("Invalid chapter");
  break;
}

importGroup.Import();
ChangeSelection(scr_84_get_lang_string);
