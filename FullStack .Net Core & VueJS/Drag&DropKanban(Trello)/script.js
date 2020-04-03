let drag_node = null;
let drag_column = null;
let drag_column1 = null;
let drag_enter = null;

document.querySelectorAll(".node").forEach(nodes);
document.querySelectorAll(".column").forEach(columns);

function createElement() {
    let node_new = document.createElement("div");
    node_new.classList.add("node");
    node_new.classList.add("temp");
    return node_new;
}


function columns(column) {

    column.addEventListener("dragover", dragover_column);
    column.addEventListener("drop", drop_column);
    column.addEventListener("dragleave", dragleave_column);
}

function dragover_column(event) {

    event.preventDefault();
    document.querySelectorAll(".node").forEach(nodes);

    if (this == drag_column) {
        return;
    } else {
        drag_column1 = this;

        let div = drag_column1.querySelector(".temp");

        if (!div) {
            this.insertAdjacentElement('afterbegin', createElement());
            document.querySelectorAll(".temp").forEach(nodes);
            console.log("else1afterbegin");
            return;
        }
        console.log("else1");
        return;
    }
}

function drop_column(event) {
    event.stopPropagation();
    console.log(drag_node);
    this.insertAdjacentElement('beforeend', drag_node);
    let div = drag_column1.querySelector(".temp");

    if (div) {
        div.remove();
    }
}

function dragleave_column(event) {
    console.log("dragleave_column");
    if (!drag_enter) {
        if (!drag_column1) {
            console.log("return dragleave_column");

            return;
        }
        let div = drag_column1.querySelector(".temp");

        if (div) {
            console.log(this);
            console.log("remove dragleave_column");

            div.remove();

        }
        return;
    }
    if (drag_column1 && !(drag_enter.parentElement == this)) {


        let div = drag_column1.querySelector(".temp");

        if (div) {
            console.log(this);

            div.remove();
        }
    }
}

function nodes(node) {

    node.addEventListener("dragstart", dragstart_node);
    node.addEventListener("dragend", dragend_node);
    node.addEventListener("dragenter", dragenter_node);
    node.addEventListener("dragover", dragover_node);
    node.addEventListener("dragleave", dragleave_node);
    node.addEventListener("drop", drop_node);
}

function dragstart_node(event) {
    drag_node = this;
    drag_column = this.parentElement;
    this.classList.add("dragElement");


    event.stopPropagation();
}

function dragend_node(event) {
    drag_node = null;
    this.classList.remove("dragElement");

    document.querySelectorAll(".node").forEach(x => x.classList.remove("under"));
}

function dragenter_node(event) {
    event.stopPropagation();

    if (this == drag_node) {
        console.log(this);

        console.log("this == drag_node");

        return;
    }

    drag_enter = this;

    console.log("dragenter_node");
    console.log(this);

    this.classList.add("under");


    //создать временный элемент под элементом
    if (drag_column1) {
        return
    }
    let divNode = drag_column1.querySelector(".temp");
    if (divNode == drag_enter) {
        console.log("TestTTTTT");
        return;
    }
    console.log("dragenter_node1");
}

function dragover_node(event) {
    event.preventDefault();
    if (this == drag_node) {
        return;
    }
}

function dragleave_node(event) {
    console.log("dragleave_node");

    if (this == drag_node) {
        console.log("this == drag_node");

        return;
    }
    this.classList.remove("under");
    console.log("dragleave_node");

    drag_enter = null;

}

function drop_node(event) {
    event.stopPropagation();
    console.log("drop_node");

    if (this == drag_node) {
        return;
    }

    if (this.parentElement == drag_node.parentElement) {
        let node = Array.from(this.parentElement.querySelectorAll(".node"));
        let i = node.indexOf(this);
        let y = node.indexOf(drag_node);
        this.insertAdjacentElement('afterend', drag_node);
        console.log(this);

        console.log("afterend");

        if (i < y) {
            this.insertAdjacentElement('beforebegin', drag_node);
        } else {
            this.insertAdjacentElement('afterend', drag_node);
        }
    } else {
        this.insertAdjacentElement('beforebegin', drag_node);
    }
    if (drag_column1) {
        let div = drag_column1.querySelector(".temp");

        if (div) {
            div.remove();
        }
    }
}