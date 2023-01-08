CanvasMediator = {
    table.insert(GameLoopLua.List, CanvasMediator)
}

local AbMediator
local canvas

require "GameLoopLua"

function CanvasMediator:Update()
    print("CanvasMediator Update")
end

function CanvasMediator:FixedUpdate()
    print("CanvasMediator FixedUpdate")
end

