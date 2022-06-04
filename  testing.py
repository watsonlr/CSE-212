# testing
# adding back via MBP
"""
s a violation of BYU-Idaho Honor Code to post or share this code with others or 
to post it online.  Storage into a personal and private repository (e.g. private
GitHub repository, unshared Google Drive folder) is acceptable.
"""
from gettext import find

def reverse(item):
    return item [::-1]


def find_pairs(words):
    """
    The words parameter contains a list of two character 
    words (lower case, no duplicates). Using sets, find an O(n) 
    solution for displaying all symmetric pairs of words.  

    For example, if words was: [am, at, ma, if, fi], we would display:

    am & ma
    if & fi

    The order of the display above does not matter.  'at' would not 
    be displayed because 'ta' is not in the list of words.

    As a special case, if the letters are the same (example: 'aa') then
    it would not match anything else (remember no the assumption above
    that there were no duplicates) and therefore should not be displayed.
    """    
      # new_set = set(words)
    #new_list = list(map(reverse, words))
    #track_items = []
    #for item in words:
        #if item in new_list and item != reverse(item) and reverse(item) not in track_items:
            #print(item, reverse(item))
        #track_items.append(item)
    
    pairs = set()
    for (a, b) in words:
        pairs.add((a, b))
        if (a, b) == (a, a) or (a, b) == (b, b):
            pairs.remove((a, b))
        if (b, a) in pairs:
            print((a, b), '&', (b, a))

find_pairs(["am","at","ma","if","fi"])      # ma & am, fi & if
print("=============")
find_pairs(["ab", "bc", "cd", "de", "ba"])  # ba & ab
print("=============")
find_pairs(["ab","ba","ac","ad","da","ca"]) # ba & ab, da & ad, ca & ac
print("=============")
find_pairs(["ab", "ac"])                    # None
print("=============")
find_pairs(["ab", "aa", "ba"])              # ba & ab
print("=============")
find_pairs(["23","84","49","13","32","46","91","99","94","31","57","14"])
                                            # 32 & 23, 94 & 49, 31 & 13