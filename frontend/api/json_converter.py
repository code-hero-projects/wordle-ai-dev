import json

def to_json(obj):
      return json.dumps(obj, default=lambda obj: obj.__dict__)
  
def from_json(obj):
  return json.loads(obj)