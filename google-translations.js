// Populate all languages
// The selectors change each time you load the page.
var languageSelector = '.MYADMIB-Vf-n.MYADMIB-Vf-o.MYADMIB-Y-c';
var inputSelector = '.MYADMIB-Gj-a';
var length = $$(languageSelector + ' a').length;

var name = 'Rocket Pants';
var shortDescription = 'Meet Hank Wood, the first of mankind to try pants with a built in rocket system.';
var description = "Hank quickly threw his regular pants out the window and went looking for the tallest tree he could find...\n\nWhat's in all of this Rocket Pants talk for me, you ask? Well, you can take part in this, the revolution of the world of pants, by helping out: Press left or right to switch sides. Hold left or right to use the Rocket Pants system. Easy to learn, hard to master.";

for (var i = 0; i < length; i++) {
  $$(languageSelector + ' a')[i].click();

  $(inputSelector + ' input').value = name;
  $$(inputSelector + ' textarea')[0].value = shortDescription;
  $$(inputSelector + ' textarea')[1].value = description;
}


// Check all languages
// The selectors change each time you load the page.
var languageSelector = '.MYADMIB-Vf-n.MYADMIB-Vf-o.MYADMIB-Y-c';
var inputSelector = '.MYADMIB-Gj-a';
var length = $$(languageSelector + ' a').length;

for (var i = 0; i < length; i++) {
  $$(languageSelector + ' a')[i].click();
  console.log($$(inputSelector + ' textarea')[0].value);
}
