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
  case "1&2": // Demo
  var scr_84_get_lang_string_ch1 = Data.Scripts.ByName("scr_84_get_lang_string_ch1")?.Code;

  if (scr_84_get_lang_string_ch1 is not UndertaleCode) {
    ScriptError("scr_84_get_lang_string_ch1 is missing");
  }

  importGroup.QueueFindReplace(scr_84_get_lang_string_ch1, "return ds_map_find_value(global.lang_map, arg0);", @"var text = ds_map_find_value(global.lang_map, arg0);
  if (variable_global_exists(""othername"") && is_array(global.othername)) {
    text = string_replace(text, ""KRIS"", global.othername[0]);
    text = string_replace(text, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    text = string_replace(text, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    text = string_replace(text, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  return text;");

  var msgsetDemo = Data.Scripts.ByName("msgset")?.Code;

  if (msgsetDemo is not UndertaleCode) {
    ScriptError("msgset is missing");
  }

  importGroup.QueueFindReplace(msgsetDemo, "global.msg[arg0] = arg1;", @"if (variable_global_exists(""othername"") && is_array(global.othername)) {
    arg1 = string_replace(arg1, ""KRIS"", global.othername[0]);
    arg1 = string_replace(arg1, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    arg1 = string_replace(arg1, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    arg1 = string_replace(arg1, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  global.msg[arg0] = arg1;");
  break;
  case "1":
  importGroup.QueueFindReplace(scr_84_get_lang_string, "return ds_map_find_value(global.lang_map, arg0);", @"var text = ds_map_find_value(global.lang_map, arg0);
  if (variable_global_exists(""othername"") && is_array(global.othername)) {
    text = string_replace(text, ""KRIS"", global.othername[0]);
    text = string_replace(text, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    text = string_replace(text, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    text = string_replace(text, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  return text;");
  break;
  case "2":
  case "3":
  case "4":
  case "5":
  var msgset = Data.Scripts.ByName("msgset")?.Code;

  if (msgset is not UndertaleCode) {
    ScriptError("msgset is missing");
  }

  importGroup.QueueFindReplace(msgset, "global.msg[arg0] = arg1;", @"if (variable_global_exists(""othername"") && is_array(global.othername)) {
    arg1 = string_replace(arg1, ""KRIS"", global.othername[0]);
    arg1 = string_replace(arg1, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    arg1 = string_replace(arg1, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    arg1 = string_replace(arg1, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  global.msg[arg0] = arg1;");

  var stringset = Data.Scripts.ByName("stringset")?.Code;

  if (stringset is not UndertaleCode) {
    ScriptError("stringset is missing");
  }

  importGroup.QueueFindReplace(stringset, "return arg0;", @"if (variable_global_exists(""othername"") && is_array(global.othername)) {
    arg0 = string_replace(arg0, ""KRIS"", global.othername[0]);
    arg0 = string_replace(arg0, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));
    arg0 = string_replace(arg0, ""K.."", string_char_at(global.othername[0], 1) + ""..."");
    arg0 = string_replace(arg0, ""K-"", string_char_at(global.othername[0], 1) + ""-"");
  };
  return arg0;");
  break;
  default:
  ScriptError("Invalid chapter");
  break;
}

importGroup.Import();
ChangeSelection(scr_84_get_lang_string);
