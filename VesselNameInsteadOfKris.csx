EnsureDataLoaded();

UndertaleModLib.Compiler.CodeImportGroup importGroup = new(Data);

string displayName = Data.GeneralInfo.DisplayName.Content;

if (!displayName.StartsWith("DELTARUNE Chapter"))
{
  ScriptError("This script is for DELTARUNE chapters only");
}

string chapter = displayName.Split(" ")[2];

void replaceLangString()
{
  var scr_84_get_lang_string = Data.Scripts.ByName("scr_84_get_lang_string")?.Code;

  if (scr_84_get_lang_string is not UndertaleCode) {
    ScriptError("scr_84_get_lang_string is missing");
  }

  importGroup.QueueFindReplace(scr_84_get_lang_string, "return ds_map_find_value(global.lang_map, arg0);", @"var text = ds_map_find_value(global.lang_map, arg0);
  if (variable_global_exists(""othername"") && is_array(global.othername)) {
    text = string_replace_all(text, ""KRIS"", global.othername[0]);
    text = string_replace_all(text, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));

    text = string_replace_all(text, ""OK"", ""[TEMP_OK]"");

    text = string_replace_all(text, ""K.."", string_char_at(global.othername[0], 1) + "".."");
    text = string_replace_all(text, ""Kr.."", string_char_at(global.othername[0], 1) + string_char_at(string_lower(global.othername[0]), 2) + "".."");
    text = string_replace_all(text, ""K-"", string_char_at(global.othername[0], 1) + ""-"");

    text = string_replace_all(text, ""[TEMP_OK]"", ""OK"");
  };
  return text;");

  importGroup.Import();
  ChangeSelection(scr_84_get_lang_string);
}

void replaceLangStringCh1()
{
  var scr_84_get_lang_string_ch1 = Data.Scripts.ByName("scr_84_get_lang_string_ch1")?.Code;

  if (scr_84_get_lang_string_ch1 is not UndertaleCode) {
    ScriptError("scr_84_get_lang_string_ch1 is missing");
  }

  importGroup.QueueFindReplace(scr_84_get_lang_string_ch1, "return ds_map_find_value(global.lang_map, arg0);", @"var text = ds_map_find_value(global.lang_map, arg0);
  if (variable_global_exists(""othername"") && is_array(global.othername)) {
    text = string_replace_all(text, ""KRIS"", global.othername[0]);
    text = string_replace_all(text, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));

    text = string_replace_all(text, ""OK"", ""[TEMP_OK]"");

    text = string_replace_all(text, ""K.."", string_char_at(global.othername[0], 1) + "".."");
    text = string_replace_all(text, ""Kr.."", string_char_at(global.othername[0], 1) + string_char_at(string_lower(global.othername[0]), 2) + "".."");
    text = string_replace_all(text, ""K-"", string_char_at(global.othername[0], 1) + ""-"");

    text = string_replace_all(text, ""[TEMP_OK]"", ""OK"");
  };
  return text;");

  importGroup.Import();
  ChangeSelection(scr_84_get_lang_string_ch1);
}

void replaceMsgSet()
{
  var msgset = Data.Scripts.ByName("msgset")?.Code;

  if (msgset is not UndertaleCode) {
    ScriptError("msgset is missing");
  }

  importGroup.QueueFindReplace(msgset, "global.msg[arg0] = arg1;", @"if (variable_global_exists(""othername"") && is_array(global.othername)) {
    arg1 = string_replace_all(arg1, ""KRIS"", global.othername[0]);
    arg1 = string_replace_all(arg1, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));

    arg1 = string_replace_all(arg1, ""OK"", ""[TEMP_OK]"");

    arg1 = string_replace_all(arg1, ""K.."", string_char_at(global.othername[0], 1) + "".."");
    arg1 = string_replace_all(arg1, ""Kr.."", string_char_at(global.othername[0], 1) + string_char_at(string_lower(global.othername[0]), 2) + "".."");
    arg1 = string_replace_all(arg1, ""K-"", string_char_at(global.othername[0], 1) + ""-"");

    arg1 = string_replace_all(arg1, ""[TEMP_OK]"", ""OK"");
  };
  global.msg[arg0] = arg1;");

  importGroup.Import();
  ChangeSelection(msgset);
}

void replaceStringSet()
{
  var stringset = Data.Scripts.ByName("stringset")?.Code;

  if (stringset is not UndertaleCode) {
    ScriptError("stringset is missing");
  }

  importGroup.QueueFindReplace(stringset, "return arg0;", @"if (variable_global_exists(""othername"") && is_array(global.othername)) {
    arg0 = string_replace_all(arg0, ""KRIS"", global.othername[0]);
    arg0 = string_replace_all(arg0, ""Kris"", string_char_at(global.othername[0], 1) + string_copy(string_lower(global.othername[0]), 2, string_length(global.othername[0]) - 1));

    arg0 = string_replace_all(arg0, ""OK"", ""[TEMP_OK]"");

    arg0 = string_replace_all(arg0, ""K.."", string_char_at(global.othername[0], 1) + "".."");
    arg0 = string_replace_all(arg0, ""Kr.."", string_char_at(global.othername[0], 1) + string_char_at(string_lower(global.othername[0]), 2) + "".."");
    arg0 = string_replace_all(arg0, ""K-"", string_char_at(global.othername[0], 1) + ""-"");

    arg0 = string_replace_all(arg0, ""[TEMP_OK]"", ""OK"");
  };
  return arg0;");

  importGroup.Import();
  ChangeSelection(stringset);
}

switch (chapter)
{
  case "1&2": // Demo
  replaceLangStringCh1();
  replaceMsgSet();
  replaceStringSet();
  break;
  case "1":
  replaceLangString();
  break;
  case "2":
  case "3":
  case "4":
  case "5":
  replaceMsgSet();
  replaceStringSet();
  break;
  default:
  ScriptError("Invalid chapter");
  break;
}
