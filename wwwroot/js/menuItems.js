$(document).ready(function () {
    $(".menu-items").each(function () {
        const menuBox = $(this)
        const items = menuBox.children('.menu-items-row')
        menuBox.find(".menu-items-addBtn").on("click", function () {
            const count = (+items.attr("data-count")) || 0
            const Input = document.createElement("input")
            Input.classList.add("form-control")
            const nameInput = Input.cloneNode(true);
            nameInput.setAttribute("placeholder", "name")
            const nameLabel = document.createElement("label")
            nameLabel.innerText = "Name"
            const descInput = Input.cloneNode();
            descInput.classList.add("form-control")
            descInput.setAttribute("placeholder", "desc")
            const descLabel = document.createElement("label")
            descLabel.innerText = "Description"
            const priceInput = Input.cloneNode();
            priceInput.classList.add("form-control")
            priceInput.setAttribute("placeholder", "price")
            priceInput.setAttribute("type", "number")
            const priceLabel = document.createElement("label")
            priceLabel.innerText = "Price"

            const Container = document.createElement('div')
            Container.classList.add("col-12")
            const Row = document.createElement('div')
            Row.classList.add("row", "justify-content-between", "menu-items-row", "px-5","menu-item-row")
            const InputBox = document.createElement('div')
            InputBox.classList.add("col-lg-3", "col-6")
            const InputGroup = document.createElement('div')
            InputGroup.classList.add("input-group", "mb-3")
            const FloatForm = document.createElement('div')
            FloatForm.classList.add("form-floating", "w-100")
            InputGroup.append(FloatForm)
            InputBox.append(InputGroup)
            
            const NameBox = InputBox.cloneNode(true)
            NameBox.childNodes[0].childNodes[0].append(nameInput, nameLabel)
            const DescBox = InputBox.cloneNode(true)
            DescBox.childNodes[0].childNodes[0].append(descInput, descLabel)
            const PriceBox = InputBox.cloneNode(true)
            PriceBox.childNodes[0].childNodes[0].append(priceInput,priceLabel)

            const BtnBox = document.createElement("div")
            BtnBox.classList.add("col-1","pt-2")
            const removeBtn = document.createElement("button")
            removeBtn.classList.add("btn","btn-danger","menu-items-removeBtn")
            removeBtn.setAttribute("type", "button")
            removeBtn.innerText="-"
            removeBtn.addEventListener("click",remove)
            BtnBox.append(removeBtn)

            Row.append(NameBox, DescBox, PriceBox, BtnBox)
            Container.append(Row)
            items.append(Container)
            items.find(".menu-item-row").each(function(rowIdx){
                const Row = $(this)
                Row.parent().attr("id", `item-${rowIdx}`)
                Row.find("input").each(function(idx){
                    this.setAttribute("name",`items[${rowIdx}].${idx ? idx > 1 ? "Price" : "Desc" : "Name"}`)
                })
                Row.find(".menu-items-removeBtn").attr("data-target", `#item-${rowIdx}`)
            })
            items.attr("data-count", count + 1)
        })
        function remove(){
            const count = +items.attr("data-count") || 0
            const target = this.getAttribute("data-target")
            console.log(target)
            if (count > 1 && target) {
                console.log(target)
                items.find(target).remove()
                items.attr("data-count", count - 1)
            }
        }
        menuBox.find(".menu-items-removeBtn").on("click", remove)
        
    })
})